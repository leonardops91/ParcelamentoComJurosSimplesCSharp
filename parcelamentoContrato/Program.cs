using parcelamentoContrato.Entities;
using parcelamentoContrato.Services;
using System;
using System.Globalization;


namespace parcelamentoContrato
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Contract number: ");
            int contractNumber = int.Parse(Console.ReadLine());
            Console.Write("Contract Date (dd/MM/yyyy): ");
            DateTime contractDate = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract Value: $ ");
            double contractValue = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Contract contract = new Contract(contractNumber, contractDate, contractValue, new PayPalPayment());

            Console.Write("Enter number of installments: ");
            int numberOfInstallments = int.Parse(Console.ReadLine());

            for(int i = 0; i < numberOfInstallments; i++)
            {
                double baseInstallment = contractValue / numberOfInstallments;
                double monthlyAmount = contract.Payment.ProcessPayment(baseInstallment, i+1);

                DateTime dueDate = contractDate.AddMonths(i + 1);

                Installment installment = new Installment(dueDate, monthlyAmount);

                contract.Installments.Add(installment);
            }
            Console.WriteLine();
            Console.WriteLine("installments:");
            foreach(Installment i in contract.Installments)
            {
                Console.WriteLine(i);
            }
        }
    }
}
