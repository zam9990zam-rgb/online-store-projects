using System;

namespace IPG_OOP_Project.Core
{
    public delegate void StatusChangeHandler(string deviceName, bool newStatus);

    /// <summary>
    /// فئة الأجهزة الإلكترونية - تم التعديل والتحسين
    /// Modified by: Student
    /// </summary>
    public class ElectronicDevice : AbstractBase 
    {
        // الحقول الخاصة
        private string name;
        private string model;
        private bool ison;
        private double power;
        
        // إضافة: حقل جديد لتتبع عدد مرات التشغيل
        private int usageCount;
        
        // إضافة: حقل لتاريخ آخر استخدام
        private DateTime lastUsedTime;

        // الحدث الخاص بتغيير الحالة
        public event StatusChangeHandler OnStatusChanged;

        /// <summary>
        /// المُنشئ - تم تحسينه بإضافة قيم افتراضية
        /// </summary>
        public ElectronicDevice(string deviceName, string modelNumber, double powerConsumptionWatts)
        {
            name = deviceName;
            model = modelNumber;
            ison = false; 
            power = powerConsumptionWatts;
            
            // إضافة: تهيئة الحقول الجديدة
            usageCount = 0;
            lastUsedTime = DateTime.MinValue;
        }

        // الخصائص العامة
        public string DeviceName
        {
            get { return name; }
        }

        public bool IsPoweredOn
        {
            get { return ison; }
        }
        
        // إضافة: خاصية جديدة لعرض عدد مرات الاستخدام
        public int UsageCount
        {
            get { return usageCount; }
        }
        
        // إضافة: خاصية جديدة لعرض آخر وقت استخدام
        public DateTime LastUsedTime
        {
            get { return lastUsedTime; }
        }
        
        // إضافة: خاصية جديدة لحساب استهلاك الطاقة الإجمالي
        public string PowerConsumptionLevel
        {
            get
            {
                if (power < 50) return "Low";
                else if (power < 200) return "Medium";
                else return "High";
            }
        }

        /// <summary>
        /// تشغيل الجهاز - تم تحسينه بإضافة تتبع الاستخدام
        /// </summary>
        public void TurnOn()
        {
            if (!ison)
            {
                ison = true;
                usageCount++; // إضافة: زيادة عداد الاستخدام
                lastUsedTime = DateTime.Now; // إضافة: تحديث وقت الاستخدام
                Console.WriteLine(name + " is turning ON. (Usage #" + usageCount + ")");
                OnStatusChanged?.Invoke(name, ison);
            }
            else
            {
                Console.WriteLine(name + " is already ON.");
            }
        }

        /// <summary>
        /// إيقاف الجهاز - تم تحسينه برسالة أوضح
        /// </summary>
        public void TurnOff()
        {
            if (ison)
            {
                ison = false;
                Console.WriteLine(name + " is turning OFF. (Total usage: " + usageCount + " times)");
                OnStatusChanged?.Invoke(name, ison);
            }
            else
            {
                Console.WriteLine(name + " is already OFF.");
            }
        }
        
        // إضافة: دالة جديدة لإعادة تعيين عداد الاستخدام
        public void ResetUsageCounter()
        {
            usageCount = 0;
            Console.WriteLine(name + " usage counter has been reset.");
        }
        
        // إضافة: دالة جديدة لحساب تكلفة الطاقة التقديرية
        public double CalculateEnergyCost(double hoursUsed, double costPerKWh)
        {
            // الطاقة بالكيلووات × الساعات × التكلفة لكل كيلووات ساعة
            double energyKWh = (power / 1000.0) * hoursUsed;
            return energyKWh * costPerKWh;
        }

        /// <summary>
        /// عرض التفاصيل - تم تحسينه بإضافة معلومات إضافية
        /// </summary>
        public override void DisplayDetails()
        {
            Console.WriteLine("========== Device Details ==========");
            Console.WriteLine("Name: " + name);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Status: " + (ison ? "ON" : "OFF"));
            Console.WriteLine("Power Consumption: " + power + "W (" + PowerConsumptionLevel + ")");
            Console.WriteLine("Total Usage Count: " + usageCount + " times");
            
            // إضافة: عرض آخر وقت استخدام
            if (lastUsedTime != DateTime.MinValue)
            {
                Console.WriteLine("Last Used: " + lastUsedTime.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                Console.WriteLine("Last Used: Never");
            }
            
            Console.WriteLine("====================================");
        }
    }
}

