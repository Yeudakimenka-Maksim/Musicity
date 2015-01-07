﻿using System.Collections.Generic;

namespace Mvc.PL.ViewModels.Other
{
    public class RoleViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<UserViewModel> Users { get; set; }
    }
}