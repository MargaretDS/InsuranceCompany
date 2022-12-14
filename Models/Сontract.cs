//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace InsuranceCompany.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Сontract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Сontract()
        {
            this.Signature = new HashSet<Signature>();
        }
    
        public int ContractId { get; set; }
        public int AgentId { get; set; }
        public int CompanyId { get; set; }
        public int SignatureId { get; set; }
        public int PaymentId { get; set; }
        public int SumId { get; set; }
        public System.DateTime ConclusionDate { get; set; }
        public System.DateTime Period { get; set; }
    
        public virtual CategorySum CategorySum { get; set; }
        public virtual Company Company { get; set; }
        public virtual InsuranceAgent InsuranceAgent { get; set; }
        public virtual InsurancePayments InsurancePayments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Signature> Signature { get; set; }
    }
}
