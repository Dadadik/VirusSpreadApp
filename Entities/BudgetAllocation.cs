//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ViruseSpreadApp.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class BudgetAllocation
    {
        public int Id { get; set; }
        public int CityId { get; set; }
        public int PossibleStrategyId { get; set; }
        public double Payment { get; set; }
        public System.DateTime DateTime { get; set; }
    
        public virtual City City { get; set; }
        public virtual PossibleStrategy PossibleStrategy { get; set; }
    }
}
