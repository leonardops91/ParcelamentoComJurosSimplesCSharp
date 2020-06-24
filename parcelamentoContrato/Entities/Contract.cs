using parcelamentoContrato.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace parcelamentoContrato.Entities
{
    class Contract
    {
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public List<Installment> Installments { get; set; } 

        public IPayment Payment;

        public Contract()
        {

        }

        public Contract(int number, DateTime date, double value, IPayment payment)
        {
            Number = number;
            Date = date;
            Value = value;
            Installments = null;
            Payment = payment;
            Installments = new List<Installment>();
        }

        public override string ToString()
        {
            return "Contract nº: "
                + Number
                + "\nContract date: "
                + Date.ToString("dd/MM/yyyy")
                + "\nContract value: $ "
                + Value.ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
