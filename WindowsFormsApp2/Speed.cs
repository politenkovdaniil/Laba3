using System;

namespace WindowsFormsApp2
{
    public enum MeasureType { m, km, u, max };//типы скорости
    public class Speed
    {
        // конструктор значение, тип
        private double value;
        private MeasureType type;

        public Speed(double value, MeasureType type)
        {
            this.value = value;
            this.type = type;
        }

        public string Verbose()//функция вывода
        {
            string typeVerbose = "";
            switch (this.type)
            {
                case MeasureType.m:
                    typeVerbose = "м/с";
                    break;
                case MeasureType.km:
                    typeVerbose = "км/ч";
                    break;
                case MeasureType.u:
                    typeVerbose = "узел";
                    break;
                case MeasureType.max:
                    typeVerbose = "мах";
                    break;
            }
            return String.Format("{0} {1}", this.value, typeVerbose);
        }

        public static Speed operator +(Speed instance, double number)//сумма
        {
            var newValue = instance.value + number;
            var Speed = new Speed(newValue, instance.type);
            return Speed;
        }

        public static Speed operator +(double number, Speed instance)
        {
            return instance + number;
        }

        public static Speed operator *(Speed instance, double number)//умножение
        {
            return new Speed(instance.value * number, instance.type); ;
        }

        public static Speed operator *(double number, Speed instance)
        {
            return instance * number;
        }

        public static Speed operator -(Speed instance, double number)//вычитание
        {
            return new Speed(instance.value - number, instance.type);
        }

        public static Speed operator -(double number, Speed instance)
        {
            return instance - number;
        }

        public static Speed operator >(Speed instance, double number)//больше 
        {
            if (instance.value > number)
            {
                return new Speed(instance.value, instance.type);
            }
            else
            {
                return new Speed(number, instance.type);
            }
        }

        public static Speed operator <(Speed instance, double number)//меньше
        {
            if (instance.value < number)
            {
                return new Speed(instance.value, instance.type);
            }
            else
            {
                return new Speed(number, instance.type);
            }
        }

        public Speed To(MeasureType newType)//функция перевода
        {
            var newValue = this.value;
            if (this.type == MeasureType.m)//из метров в другие типы
            {
                switch (newType)
                {
                    case MeasureType.m:
                        newValue = this.value;
                        break;
                    case MeasureType.km:
                        newValue = this.value * 3.6;
                        break;
                    case MeasureType.u:
                        newValue = this.value * 1.944;
                        break;
                    case MeasureType.max:
                        newValue = this.value / 340.29;
                        break;
                }
            }
            else if (newType == MeasureType.m)//из других типов в метры
            {
                switch (this.type)
                {
                    case MeasureType.m:
                        newValue = this.value;
                        break;
                    case MeasureType.km:
                        newValue = this.value / 3.6;
                        break;
                    case MeasureType.u:
                        newValue = this.value / 1.944;
                        break;
                    case MeasureType.max:
                        newValue = this.value * 340.29;
                        break;
                }
            }
            else
            {
                newValue = this.To(MeasureType.m).To(newType).value;
            }
            return new Speed(newValue, newType);
        }

        public static Speed operator +(Speed instance1, Speed instance2)//сумма разных типов
        {
            return instance1 + instance2.To(instance1.type).value;
        }

        public static Speed operator -(Speed instance1, Speed instance2)//разность разных типов
        {
            return instance1 - instance2.To(instance1.type).value;
        }

        public static Speed operator *(Speed instance1, Speed instance2)//умножение разных типов
        {
            return instance1 * instance2.To(instance1.type).value;
        }
        public static Speed operator >(Speed instance1, Speed instance2)//больше разных типов
        {
            return instance1 > instance2.To(instance1.type).value;
        }
        public static Speed operator <(Speed instance1, Speed instance2)//меньше разных типов
        {
            return instance1 < instance2.To(instance1.type).value;
        }
    }
}
