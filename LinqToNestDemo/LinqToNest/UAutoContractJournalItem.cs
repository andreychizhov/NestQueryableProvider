namespace LinqToNestDemo
{
    using System;
    using System.Collections.Generic;

    public class UAutoContractJournalItem
    {
        public int Id { get; set; }

        public string PolicySerialValue { get; set; }

        public string PolicyPrefix { get; set; }

        public string PolicyNumber { get; set; }

        public string InsuredLastName { get; set; }

        public string InsuredFirstName { get; set; }

        public string InsuredMiddleName { get; set; }

        public string InsuredOrgName { get; set; }

        public string InsuredContractorType { get; set; }

        public DateTimeOffset? SigningDate { get; set; }

        public DateTimeOffset? ContractFrom { get; set; }

        public DateTimeOffset? ContractTo { get; set; }

        public string EmployeeFilialName { get; set; }

        public int EmployeeFilialId { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeId { get; set; }

        public int FilialId { get; set; }

        public string VehicleVehicleModelSpelt { get; set; }

        public string SellerComment { get; set; }

        public string StatusName { get; set; }

        public int StatusCode { get; set; }

        public string EmployeePointOfSaleName { get; set; }

        public string EmployeeIntermediateSellerName { get; set; }

        public decimal InsuranceAmount { get; set; }

        public decimal? SummaryPremium { get; set; }

        public decimal Discount { get; set; }

        public string FilialName { get; set; }

        public bool DiscountIsNumeric { get; set; }

        public bool IsTowardInspection { get; set; }

        public bool InspectionConclusion_InspectionIsNotRequired { get; set; }
    }
}
