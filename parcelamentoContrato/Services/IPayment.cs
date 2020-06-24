


namespace parcelamentoContrato.Services
{
    interface IPayment
    {
        public double InterestPerMonth { get; set; }
        public double PaymentTax { get; set; }

        public double ProcessPayment(double montlyValue, int numberOfMonths);
    }
}
