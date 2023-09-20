namespace MyApp.Contracts.DTOs
{
    /// <summary>
    /// Форма для расчета стоимости доставки
    /// </summary>
    public class CalculateDeliveryRequest
    {
        /// <summary>
        /// Вес в граммах
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        /// Ширина в миллиметрах
        /// </summary>
        public float Width { get; set; }

        /// <summary>
        /// Высота в миллиметрах
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Длина в миллиметрах
        /// </summary>
        public float Length { get; set; }

        /// <summary>
        /// ФИАС код города отправления
        /// </summary>
        public Guid FIASSenderCity { get; set; }

        /// <summary>
        /// ФИАС код города получения
        /// </summary>
        public Guid FIASReceivingCity { get; set; }
    }
}
