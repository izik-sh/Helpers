using Newtonsoft.Json;
using System;
using System.Collections.Generic;


public class GetJson
{
    public class Bill
    {
        public int Quantity { get; set; }
        public decimal Amount { get; set; }
        public string Counterfeits { get; set; }
    }

    public class Line
    {
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string StoreName { get; set; }
        public string BagId { get; set; }
        public decimal DeclaredAmount { get; set; }
        public decimal AmountCounted { get; set; }
        public decimal DifferenceAmount { get; set; }
        public int AmountOfCounterfeits { get; set; }
        public string ShippingCode { get; set; }
        public string BarcodeBag { get; set; }
        //public List<Bill> Bill200 { get; set; }
        //public List<Bill> Bill100 { get; set; }
        //public List<Bill> Bill50 { get; set; }

        public Bill Bill200 { get; set; }
        public Bill Bill100 { get; set; }
        public Bill Bill50 { get; set; }
    }

    public class BankTransaction
    {
        public string BankId { get; set; }
        public string BankBranchId { get; set; }
        public string BankAccountNumber { get; set; }
        public string DepositDate { get; set; }
        public List<Line> Lines { get; set; }  // List of "line"
    }

    public object GetJsonExample()
    {
       string json = @"
        {
            ""BankId"": ""010"",
            ""BankBranchId"": ""123"",
            ""BankAccountNumber"": ""123456789"",
            ""DepositDate"": ""2024-12-23"",
            ""lines"": [
                {
                    ""BranchId"": 1,
                    ""BranchName"": ""Glilot"",
                    ""StoreName"": ""Glilot-24"",
                    ""BagId"": ""100"",
                    ""DeclaredAmount"": 1234,
                    ""AmountCounted"": 1233.6,
                    ""DifferenceAmount"": 0.4,
                    ""AmountOfCounterfeits"": 5,
                    ""ShippingCode"": ""9711847"",
                    ""BarcodeBag"": ""300002616139BR"",
                    ""Bill200"": 
                        {
                            ""Quantity"": 3,
                            ""Amount"": 600,
                            ""Counterfeits"": """"
                        }
                    ,
                    ""Bill100"": 
                        {
                            ""Quantity"": 6,
                            ""Amount"": 600,
                            ""Counterfeits"": ""1""
                        }
                    ,
                    ""Bill50"": 
                        {
                            ""Quantity"": 6,
                            ""Amount"": 300,
                            ""Counterfeits"": ""3""
                        }
                    
                },
                {
                    ""BranchId"": 2,
                    ""BranchName"": ""Ramat Gan"",
                    ""StoreName"": ""Ramat Gan-12"",
                    ""BagId"": ""101"",
                    ""DeclaredAmount"": 1500,
                    ""AmountCounted"": 1480.5,
                    ""DifferenceAmount"": 19.5,
                    ""AmountOfCounterfeits"": 2,
                    ""ShippingCode"": ""9711848"",
                    ""BarcodeBag"": ""300002616140BR"",
                    ""Bill200"": 
                        {
                            ""Quantity"": 2,
                            ""Amount"": 400,
                            ""Counterfeits"": ""1""
                        }
                    ,
                    ""Bill100"": 
                        {
                            ""Quantity"": 4,
                            ""Amount"": 400,
                            ""Counterfeits"": ""0""
                        }
                    ,
                    ""Bill50"": 
                        {
                            ""Quantity"": 5,
                            ""Amount"": 250,
                            ""Counterfeits"": ""2""
                        }
                    
                }
            ]
        }";

        // Deserialize the JSON string to an object
        BankTransaction transaction = JsonConvert.DeserializeObject<BankTransaction>(json);

        // Output some of the values to confirm deserialization
        //Console.WriteLine($"Bank ID: {transaction.BankId}");
        //Console.WriteLine($"Branch Name: {transaction.Line.BranchName}");
        //Console.WriteLine($"Bill200 Amount: {transaction.Line.Bill200[0].Amount}");
        //Console.WriteLine($"Bill100 Counterfeits: {transaction.Line.Bill100[0].Counterfeits}");
        //Console.WriteLine($"Bill50 Quantity: {transaction.Line.Bill50[0].Quantity}");

        return transaction;
    }

}



