

namespace parcelamentoContrato.Services
{
    class PayPalPayment : IPayment
    {
        public double InterestPerMonth { get; set; } = 0.01;
        public double PaymentTax { get; set; } = 0.02;

        public double ProcessPayment(double monthlyValue, int numberOfmonths)
        {
            double interestAmount = monthlyValue + (monthlyValue * InterestPerMonth * numberOfmonths);
            double taxValue = interestAmount * PaymentTax;
            return interestAmount + taxValue;
        }

    }
}
