//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Messanger.Core.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int MassageId { get; set; }
        public int UserIdSender { get; set; }
        public Nullable<int> UserIdRecipient { get; set; }
        public string Text { get; set; }
        public System.DateTime SendDate { get; set; }
    
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
    }
}
