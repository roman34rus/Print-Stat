//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.EF
{
    using System;
    using System.Collections.Generic;
    
    public partial class SupplySlot
    {
        public int Id { get; set; }
        public int PrinterId { get; set; }
        public Nullable<int> SupplyId { get; set; }
    
        public virtual Printer Printer { get; set; }
        public virtual Supply Supply { get; set; }
    }
}
