using System;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
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

        // Флаг остановки таймера
        private bool freeze;

        // Список адаптеров
        private NetworkInterface[] adaptersList;

        private string currentMac;

        // Промежуточные данные для подсчета скорости соедиения
        private double lastSent = 0;

        private double lastReceived = 0;

        #region Старт программы *******************************************************************

        public Main()
        {
            InitializeComponent();
            Control.CheckForIllegalCrossThreadCalls = false;
            // Исправление мигания ListView
            listViewAccessPoints.DoubleBuffered(true);
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
                GetAdapters();
                Scan();
                timer1.Start();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message, "On Show Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            Cursor = Cursors.Default;
        }

        // Поверх остальных окон
        private void OnTopMenuItem_Click(object sender, EventArgs e)
        {
            if (TopMost) {
                TopMost = false;
                OnTopMenuItem.Checked = false;
            } else {
                TopMost = true;
                OnTopMenuItem.Checked = true;
            }
        }

        #endregion

        #region Timer Options *********************************************************************

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Scan();
        }

        private void FreezeMenuItem_Click(object sender, EventArgs e)
        {
            if (!freeze) {
                timer1.Stop();
                freeze = true;
                FreezeMenuItem.Text = "Unfreeze";
            } else {
                timer1.Start();
                freeze = false;
                FreezeMenuItem.Text = "Freeze";
            }
        }

        private void ThirtySecMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 500;
        }

        private void OneMinMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1000;
        }

        private void FiveMinMenuItem1_Click(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
        }

        private void TenMinMenuItem2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 10000;
        }

        #endregion Timer Options

        #region Сканирование сетей ****************************************************************

        private void Scan()
        {
            listViewAccessPoints.Items.Clear();

            foreach (WlanClient.WlanInterface wlanInterface in wlanClient.Interfaces) {
                Wlan.WlanAvailableNetwork[] networks =
                    wlanInterface.GetAvailableNetworkList(
                        Wlan.WlanGetAvailableNetworkFlags.IncludeAllAdhocProfiles |
                              Wlan.WlanGetAvailableNetworkFlags.IncludeAllManualHiddenProfiles);
                Wlan.WlanBssEntry[] wlanBssEntries = wlanInterface.GetNetworkBssList();

                if (wlanInterface.CurrentConnection.isState.ToString().Equals("Connected")) {
                    currentMac = GetMacAddress(wlanInterface.CurrentConnection.wlanAssociationAttributes.dot11Bssid);
                }

                NetworkList(networks, wlanBssEntries);
            }
            pictureBox1.Invalidate();
            GetConnectionInfo();
        }

        private void NetworkList(Wlan.WlanAvailableNetwork[] networks, Wlan.WlanBssEntry[] wlanBssEntries)
        {
            foreach (Wlan.WlanAvailableNetwork network in networks) {
                Wlan.WlanBssEntry entry = (from bs in wlanBssEntries
                                           where GetProfileName(bs.dot11Ssid).Trim() == GetProfileName(network.dot11Ssid).Trim()
                                           select bs).FirstOrDefault<Wlan.WlanBssEntry>();

                AddToList(network, entry);
            }
        }

        private void AddToList(Wlan.WlanAvailableNetwork network, Wlan.WlanBssEntry entry)
        {
            foreach (ListViewItem lvi in listViewAccessPoints.Items) {
                if (lvi.SubItems[1].Text == GetMacAddress(entry.dot11Bssid)) {
                    return;
                }
            }

            var wifiItem = new ListViewItem(GetProfileName(network.dot11Ssid));

            // MAC Address
            wifiItem.SubItems.Add(GetMacAddress(entry.dot11Bssid));

            // Signal Quality
            wifiItem.SubItems.Add(string.Format("{0}", network.wlanSignalQuality.ToString()));
            sbProgressBar.Value = (int)network.wlanSignalQuality;
            sbProgressBar.ToolTipText = string.Format("{0}%", network.wlanSignalQuality.ToString());

            // Signal Strength
            wifiItem.SubItems.Add(string.Format("{0}", entry.rssi.ToString()));
            // // смена знака

            // Channel No
            wifiItem.SubItems.Add(GetChannel(entry).ToString());
            // Encryption
            wifiItem.SubItems.Add(network.dot11DefaultCipherAlgorithm.ToString());
            // Authentication
            wifiItem.SubItems.Add(network.dot11DefaultAuthAlgorithm.ToString());
            wifiItem.ImageIndex = ((int)network.wlanSignalQuality - 1) / 25;

            if (network.dot11DefaultCipherAlgorithm.ToString().Equals("None"))
                wifiItem.BackColor = Color.LimeGreen;

            listViewAccessPoints.Items.Add(wifiItem);

            if (currentMac.Equals(GetMacAddress(entry.dot11Bssid))) {
                labelSsid.Text = GetProfileName(network.dot11Ssid);
                labelMac.Text = GetMacAddress(entry.dot11Bssid);
                labelQuality.Text = string.Format("{0}%", network.wlanSignalQuality.ToString());
                labelChannel.Text = GetChannel(entry).ToString();
                cpbStrength.Value = 100 - ((int)entry.rssi * -1);
                cpbStrength.LabelValue = entry.rssi.ToString();
            }
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

            return string.Concat(str);
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

        #endregion Вспомогательные методы

        #region Рисование графика каналов *********************************************************

        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            pictureBox1.Invalidate();
        }

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
                var color = ColorTranslator.FromHtml(_colors[Convert
                    .ToInt32(listViewAccessPoints.Items[i].SubItems[4].Text)]);
                // Карандаш для дуги
                var arcPen = new Pen(color, 1);

                // Начало по Х (№ канала - 2)
                int startArcX = (int)((axisMinorXstep * (Convert
                    .ToInt32(listViewAccessPoints.Items[i].SubItems[4].Text) - 2)) + axisShift);
                // Высота дуги
                float heightArc = (arcYstep * Convert
                    .ToInt32(listViewAccessPoints.Items[i].SubItems[2].Text)) + axisShift;
                float startArcY = (graphicsHeight - heightArc);

                // Точки линии Бизье
                var start = new Point((int)startArcX, (int)graphicsHeight);
                var control1 = new Point((int)startArcX + (int)(widthArc / 2) - 50, (int)startArcY);
                var control2 = new Point((int)startArcX + (int)(widthArc / 2) + 50, (int)startArcY);
                var end = new Point((int)startArcX + (int)widthArc, (int)graphicsHeight);

                // Рисуем дугу
                e.Graphics.DrawBezier(arcPen, start, control1, control2, end);

                // Метка дуги
                var ssid = listViewAccessPoints.Items[i].SubItems[0].Text;
                //? Коофициентт для размещения текста по центру дуги
                var koff = (widthArc - (ssid.Length * 6)) / 2;

                e.Graphics.DrawString(ssid, drawFontSsid, drawBrush, startArcX + (float)koff, startArcY, drawFormat);
            }
        }

        #endregion

        #region Информация о текущем соединении ***************************************************

        // Список доступных адаптеров Windows
        private void GetAdapters()
        {
            // Имя используемого адаптера
            string currentAdapter = "";
            // Ищем активный адаптер
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces()) {
                if (ni.OperationalStatus == OperationalStatus.Up
                    && ni.NetworkInterfaceType != NetworkInterfaceType.Tunnel
                    && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback) {
                    currentAdapter = (ni.Name);
                }
            }
            // Получаем все локальные интерфейсы компьютера
            adaptersList = NetworkInterface.GetAllNetworkInterfaces();
            int selected = 0;
            // Добавляем имя интерфейса в поле со списком
            for (int i = 0; i < adaptersList.Length; i++) {
                cbAdaptersList.Items.Add(adaptersList[i].Name);

                // Выбираем активный адаптер
                if (currentAdapter.Equals(adaptersList[i].Name)) {
                    cbAdaptersList.SelectedIndex = i;
                    selected = i;

                    //MAC адрес адаптера
                    PhysicalAddress address = adaptersList[i].GetPhysicalAddress();
                    byte[] bytes = address.GetAddressBytes();
                    labelMacAdapter.Text = GetMacAddress(bytes);

                    //IP адресс
                    //https://stackoverflow.com/questions/13174909/get-ip-address-and-adapter-description-using-c-sharp
                    var ipProps = adaptersList[i].GetIPProperties();
                    foreach (var ip in ipProps.UnicastAddresses) {
                        if ((adaptersList[i].OperationalStatus == OperationalStatus.Up)
                            && (ip.Address.AddressFamily == AddressFamily.InterNetwork)) {
                            //Console.Out.WriteLine(ip.Address.ToString() + "|" + adaptersList[i].Description.ToString());
                            labelIp.Text = ip.Address.ToString();
                        }
                    }
                }
            }
            // Выбираем активный адаптер
            cbAdaptersList.SelectedIndex = selected;
        }

        // Информация о текущем соединении
        private void GetConnectionInfo()
        {
            NetworkInterface nic = null;
            try {
                // Выбираем активный адаптер
                nic = adaptersList[cbAdaptersList.SelectedIndex];
            } catch {
                GetAdapters();
            }
            // Статистика адаптера
            IPv4InterfaceStatistics interfaceStats = nic.GetIPv4Statistics();

            // Подсчет текущей скорости
            int bytesSentSpeed = (int)(interfaceStats.BytesSent - lastSent) / 1024;
            int bytesReceivedSpeed = (int)(interfaceStats.BytesReceived - lastReceived) / 1024;

            // Update the labels
            //? labelSpeed.Text = (nic.Speed/1024).ToString()+" Kb/s";
            //Тип интерфейса
            labelType.Text = nic.NetworkInterfaceType.ToString();
            //Получено данных
            labelBytesReceived.Text = String.Format(new SizeFormatProvider(), "{0:fs}",
                interfaceStats.BytesReceived);
            lastReceived = interfaceStats.BytesReceived;
            //Отправлено данных
            labelBytesSent.Text = String.Format(new SizeFormatProvider(), "{0:fs}",
                interfaceStats.BytesSent);
            lastSent = interfaceStats.BytesSent;
            //Скорость приема
            labelUpload.Text = bytesSentSpeed.ToString() + " KB/s";
            //Скорость отдачи
            labelDownload.Text = bytesReceivedSpeed.ToString() + " KB/s";
            //Трафик за все время соединения
            labelTotal.Text = String.Format(new SizeFormatProvider(), "{0:fs}",
                interfaceStats.BytesReceived + interfaceStats.BytesSent);
        }

        #endregion
    }
}