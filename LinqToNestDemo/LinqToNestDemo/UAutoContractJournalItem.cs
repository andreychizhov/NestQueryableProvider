namespace LinqToNestDemo
{
    using System;
    using System.Collections.Generic;
    //using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    //using System.Data.Entity.Spatial;

    //[Table("UAutoContractJournalItem")]
    public class UAutoContractJournalItem
    {
        //[Key]
        //[Column(Order = 0)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public string PolicySerialValue { get; set; }

        //[StringLength(16)]
        public string PolicyPrefix { get; set; }

        //[StringLength(128)]
        public string PolicyNumber { get; set; }

        //[StringLength(128)]
        public string InsuredLastName { get; set; }

        //[StringLength(128)]
        public string InsuredFirstName { get; set; }

        //[StringLength(128)]
        public string InsuredMiddleName { get; set; }

        public string InsuredOrgName { get; set; }

        public string InsuredContractorType { get; set; }

        public DateTimeOffset? SigningDate { get; set; }

        public DateTimeOffset? ContractFrom { get; set; }

        public DateTimeOffset? ContractTo { get; set; }

        public string EmployeeFilialName { get; set; }

        //[Key]
        //[Column(Order = 1)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeFilialId { get; set; }

        //[StringLength(128)]
        public string EmployeeName { get; set; }

        //[Key]
        //[Column(Order = 2)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EmployeeId { get; set; }

        //[Key]
        //[Column(Order = 3)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FilialId { get; set; }

        public string VehicleVehicleModelSpelt { get; set; }

        public string SellerComment { get; set; }

        //[StringLength(100)]
        public string StatusName { get; set; }

        //[Key]
        //[Column(Order = 4)]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int StatusCode { get; set; }

        public string EmployeePointOfSaleName { get; set; }

        public string EmployeeIntermediateSellerName { get; set; }

        //[Key]
        //[Column(Order = 5)]
        public decimal InsuranceAmount { get; set; }

        public decimal? SummaryPremium { get; set; }

       // [Key]
        //[Column(Order = 6)]
        public decimal Discount { get; set; }

        public string FilialName { get; set; }

        //[Key]
        //[Column(Order = 7)]
        public bool DiscountIsNumeric { get; set; }

        //[Key]
        //[Column(Order = 8)]
        public bool IsTowardInspection { get; set; }

        //[Key]
        //[Column(Order = 9)]
        public bool InspectionConclusion_InspectionIsNotRequired { get; set; }
    }
}
