using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Ch2.CreatingFixture
{
    public class PlayerCharacter
    {
        [StringLength(20)]
        public string RealName { get; set; }

        [StringLength(8)]
        public string GameCharacterName { get; set; }

        [Range(0, 100)]
        public int CurrentHealth { get; set; }
    }
}
