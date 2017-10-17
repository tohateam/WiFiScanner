using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WiFiScanner;

namespace WifiScanner
{
    public partial class Main : Form
    {
        private WlanClient wlanClient = null;
        //Цвета каналов;
        private string[] _colors = { "#FFE4C4", "#6495ED", "#5F9EA0", "#7FFF00", "#00FFFF",
            "#FFD700", "#FF00FF", "#00FF7F", "#CD5C5C", "#FFA0CC54", "#CC54CC", "#FF0000",
            "#0000FF", "#DEB887", "#6495ED"
        };

        #region Старт программы *******************************************************************

        public Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
             listViewAccessPoints.Columns[2].TextAlign = HorizontalAlignment.Center;
             listViewAccessPoints.Columns[3].TextAlign = HorizontalAlignment.Center;
             listViewAccessPoints.Columns[4].TextAlign = HorizontalAlignment.Center;
             listViewAccessPoints.Columns[5].TextAlign = HorizontalAlignment.Center;
             listViewAccessPoints.Columns[6].TextAlign = HorizontalAlignment.Center;
        }

        private void FormScanner_Load(object sender, EventArgs e)
        {
            wlanClient = new WlanClient();
        }

        private void FormScanner_Shown(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;

            try {
                Scan();
                timer1.Start();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }

        #endregion

        #region Сканирование сетей ****************************************************************

        private void Scan()
        {
            listViewAccessPoints.Items.Clear();

            foreach (WlanClient.WlanInterface wlanInterface in wlanClient.Interfaces) {
                Wlan.WlanAvailableNetwork[] networks = wlanInterface.GetAvailableNetworkList(Wlan.WlanGetAvailableNetworkFlags.IncludeAllAdhocProfiles |
                                                                                              Wlan.WlanGetAvailableNetworkFlags.IncludeAllManualHiddenProfiles);
                Wlan.WlanBssEntry[] wlanBssEntries = wlanInterface.GetNetworkBssList();

                 NetworkList(networks, wlanBssEntries);
            }
            pictureBox1.Invalidate();

        }

        private void NetworkList(Wlan.WlanAvailableNetwork[] networks, Wlan.WlanBssEntry[] wlanBssEntries)
        {
            foreach (Wlan.WlanAvailableNetwork network in networks) {
                Application.DoEvents();

                Wlan.WlanBssEntry entry = (from bs in wlanBssEntries
                                           where GetProfileName(bs.dot11Ssid).Trim() == GetProfileName(network.dot11Ssid).Trim()
                                           select bs).FirstOrDefault<Wlan.WlanBssEntry>();

                 AddToList(network, entry);
            }
        }

        private void AddToList(Wlan.WlanAvailableNetwork network, Wlan.WlanBssEntry entry)
        {
            foreach (ListViewItem lvi in  listViewAccessPoints.Items) {
                if (lvi.SubItems[1].Text ==  GetMacAddress(entry.dot11Bssid)) {
                    return;
                }
            }

            var wifiItem = new ListViewItem( GetProfileName(network.dot11Ssid));

            // MAC Address
            wifiItem.SubItems.Add( GetMacAddress(entry.dot11Bssid));

            // Signal Quality
            wifiItem.SubItems.Add(string.Format("{0}", network.wlanSignalQuality.ToString()));
            //ChartValuePercent = (int)network.wlanSignalQuality;

            // dBm Value
            wifiItem.SubItems.Add(string.Format("{0}", entry.rssi.ToString()));
            //ChartValueDbm = (int)entry.rssi * -1;

            // Channel No
            wifiItem.SubItems.Add( GetChannel(entry).ToString());
            //ChartChannelX = GetChannel(entry);

            // Encryption
            wifiItem.SubItems.Add(network.dot11DefaultCipherAlgorithm.ToString());
            // Authentication
            wifiItem.SubItems.Add(network.dot11DefaultAuthAlgorithm.ToString());

            int range = ((int)network.wlanSignalQuality - 1) / 25;
            wifiItem.ImageIndex = range;

            if (network.dot11DefaultCipherAlgorithm.ToString().Equals("None"))
                wifiItem.BackColor = Color.LimeGreen;

            listViewAccessPoints.Items.Add(wifiItem);
        }

        #endregion

        #region Вспомогательные методы ************************************************************

        private string GetProfileName(Wlan.Dot11Ssid value)
        {
            return Encoding.UTF8.GetString(value.SSID, 0, (int)value.SSIDLength);
        }

        private string GetMacAddress(Byte[] value)
        {
            var macAddrLen = (uint)value.Length;
            var str = new string[(int)macAddrLen];

            for (int i = 0; i < macAddrLen; i++)
                str[i] += (value[i].ToString("x2").PadLeft(2, '0').ToUpper() + ":").Trim();

            str[str.Length - 1] = str[str.Length - 1].Remove(2, 1);

            return string.Join("", str);
        }

        private int GetChannel(Wlan.WlanBssEntry value)
        {
            int freq = (int)(value.chCenterFrequency / 1000);

            if (freq >= 2412 && freq <= 2484)
                return (freq - 2412) / 5 + 1;
            else if (freq >= 5170 && freq <= 5825)
                return (freq - 5170) / 5 + 34;
            else
                return -1;
        }

        #endregion

        #region Рисование графика каналов *********************************************************

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            #region Инициализация графика *********************************************************
            // Включаем антиалиасис
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Шрифт меток осей
            var drawFont = new Font("Arial", 6);
            // Шрифт имени Wi-Fi точки
            var drawFontSsid = new Font("Arial", 8);
            // Цвет текста
            var drawBrush = new SolidBrush(Color.White);
            // Формат текста
            var drawFormat = new StringFormat {
                FormatFlags = StringFormatFlags.DisplayFormatControl
            };

            // Цвет координатных линий
            var axisXYPen = new Pen(Color.Red, 2);
            // цвет дополнительных линий
            var axisMinorPen = new Pen(ColorTranslator.FromHtml("#FF909090"), 1) {
                DashStyle = DashStyle.DashDotDot
            };


            // Смещение осей графика относительно размеров pictureBox1
            const float axisShift = 20;
            // Размер области рисования - (Ширина/Высота - смещение)
            float graphicsWidth = (pictureBox1.Width - axisShift);
            float graphicsHeight = (pictureBox1.Height - axisShift);
            // Шаг дополнительных линий X-16 каналов, Y-10 линий
            float axisMinorXstep = graphicsWidth / 16;
            float axisMinorYstep = graphicsHeight / 10;
            // Размер шага для дуги (1 деление сетки)
            float arcYstep = graphicsHeight / 100;
            // Ширина дуги = 4-м делениям оси Х
            float widthArc = axisMinorXstep * 4;

            #endregion

            #region Рисием сетку графика **********************************************************

            // Рисуем горизонтальные линии (уровень сигнала)
            float y = graphicsHeight;
            for (int i = 0; i < 10; i++) {
                if (i == 0) {
                    // Абцисса X, начинаем от фактического 0
                    e.Graphics.DrawLine(axisXYPen, 0, y, graphicsWidth + axisShift, y);
                } else {
                    // Доюолнительные линиии
                    e.Graphics.DrawLine(axisMinorPen, axisShift, y, graphicsWidth + axisShift, y);
                    // Метки линий (10%, 20% ...)
                    e.Graphics.DrawString((i * 10).ToString() + "%", drawFont, drawBrush, 0, y - 6, drawFormat);
                }
                y -= axisMinorYstep;
            }

            // Рисуем горизонтальные линии (номер канала)
            float x = axisShift;
            for (int i = 0; i < 16; i++) {
                if (i == 0) {
                    // Абцисса Y, начинаем от фактического 0
                    e.Graphics.DrawLine(axisXYPen, x, 0, x, graphicsHeight + axisShift);
                } else {
                    e.Graphics.DrawLine(axisMinorPen, x, graphicsHeight, x, 0);
                    e.Graphics.DrawString(i.ToString(), drawFont, drawBrush, x - 3, graphicsHeight + 5, drawFormat);
                }
                x += axisMinorXstep;
            }

            #endregion
            for (int i = 0; i < listViewAccessPoints.Items.Count; i++) {
                var color = ColorTranslator.FromHtml(_colors[Convert.ToInt32(listViewAccessPoints.Items[i].SubItems[4].Text)]);
                // Карандаш для дуги
                var arcPen = new Pen(color, 1);

                // Начало по Х (№ канала - 2)
                int startArcX = (int)((axisMinorXstep * (Convert.ToInt32(listViewAccessPoints.Items[i].SubItems[4].Text) - 2)) + axisShift);
                // Высота дуги
                float heightArc = (arcYstep * Convert.ToInt32(listViewAccessPoints.Items[i].SubItems[2].Text)) + axisShift;
                float startArcY = (graphicsHeight - heightArc);

                // Точки линии Бизье
                var start = new Point((int)startArcX, (int)graphicsHeight);
                var control1 = new Point((int)startArcX + (int)(widthArc / 2) - 50, (int)startArcY);
                var control2 = new Point((int)startArcX + (int)(widthArc / 2) + 50, (int)startArcY);
                var end = new Point((int)startArcX + (int)widthArc, (int)graphicsHeight);

                // Рисуем дугу
                e.Graphics.DrawBezier(arcPen, start, control1, control2, end);
                // Метка дуги
                e.Graphics.DrawString(listViewAccessPoints.Items[i].SubItems[0].Text, drawFontSsid, drawBrush, startArcX + (widthArc / 2) - 20, startArcY, drawFormat);
            }
        }

        #endregion

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Scan();
        }
    }
}
