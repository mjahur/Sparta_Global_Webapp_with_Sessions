namespace Social
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        public int userID { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        [NotMapped] // Does not effect with your database
        [Compare("Password")]
        public string confirmpassword { get; set; }

        [Required]
        public string username { get; set; }

        public int? description_descriptionID { get; set; }

        public int? group_groupID { get; set; }

        public int? universe_universeID { get; set; }

        public virtual Description Description { get; set; }

        public virtual Group Group { get; set; }
        
        public virtual Universe Universe { get; set; }
    }
}
