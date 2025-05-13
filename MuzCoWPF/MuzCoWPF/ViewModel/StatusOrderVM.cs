using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using MuzCo;
using MuzCoWPF.Utilities;
using System.Windows.Media;


namespace MuzCoWPF.ViewModel
{
    public class StatusOrderVM : ViewModelBase
    {
        private Order _order;
        private TimeSpan elapsedTime = TimeSpan.Zero;

        private Geometry _progressPath;
        public Geometry ProgressPath
        {
            get => _progressPath;
            set { _progressPath = value; OnPropertyChanged(); }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set { _status = value; OnPropertyChanged(); }
        }

        private int _progress;
        public int Progress
        {
            get => _progress;
            set { _progress = value; OnPropertyChanged(); }
        }

        private string _displayProgress;
        public string DisplayProgress
        {
            get => _displayProgress;
            set { _displayProgress = value; OnPropertyChanged(); }
        }

        public string TimeElapsed => $"Час очікування: {elapsedTime:mm\\:ss}";
        public ICommand PizzeriaCommand { get; }
        public StatusOrderVM(Order order)
        {
            _order = order;

            Status = order.Status;
            Progress = CalculateProgress(Status);
            DisplayProgress = $"{Progress}%";
            PizzeriaCommand = NavigationVM.Instance.PizzeriaCommand;
            StartTimer();
            StartAutoUpdate();
        }

        private int CalculateProgress(string status)
        {
            int percent = status switch
            {
                "Очікує підтвердження" => 0,
                "Збирається" => 33,
                "Готується" => 66,
                "Готово" => 100,
                _ => 0
            };

            ProgressPath = CreatePieGeometry(percent);
            return percent;
        }

        private Geometry CreatePieGeometry(double percentage)
        {
            double angle = percentage * 360 / 100.0;
            double radius = 100;
            double radians = (Math.PI / 180) * angle;

            // Используем System.Windows.Point!
            System.Windows.Point center = new System.Windows.Point(radius, radius);
            System.Windows.Point startPoint = new System.Windows.Point(center.X, center.Y - radius);
            System.Windows.Point endPoint = new System.Windows.Point(
                center.X + radius * Math.Sin(radians),
                center.Y - radius * Math.Cos(radians));

            bool isLargeArc = angle > 180;

            var segment = new PathFigure
            {
                StartPoint = center,
                Segments = new PathSegmentCollection
        {
            new LineSegment(startPoint, true),
            new ArcSegment
            {
                Point = endPoint,
                Size = new System.Windows.Size(radius, radius),
                SweepDirection = SweepDirection.Clockwise,
                IsLargeArc = isLargeArc
            },
            new LineSegment(center, true)
        },
                IsClosed = true
            };

            return new PathGeometry(new[] { segment });
        }


        private async void StartTimer()
        {
            while (Status != "Готово")
            {
                await Task.Delay(1000);
                elapsedTime = elapsedTime.Add(TimeSpan.FromSeconds(1));
                OnPropertyChanged(nameof(TimeElapsed));
            }
        }

        private async void StartAutoUpdate()
        {
            Debug.WriteLine("▶ Запущено отслеживание статуса...");

            while (Status != "Готово")
            {
                await Task.Delay(3000);

                var all = Order.LoadOrders();
                var updated = all.FirstOrDefault(o => o.OrderId == _order.OrderId);

                if (updated != null && updated.Status != Status)
                {
                    Debug.WriteLine($"🔥 Обновление: {Status} → {updated.Status}");

                    Status = updated.Status;
                    Progress = CalculateProgress(Status);
                    DisplayProgress = $"{Progress}%";
                }
            }

            Debug.WriteLine("✅ Статус достиг 'Готово'");
        }



    }


}
