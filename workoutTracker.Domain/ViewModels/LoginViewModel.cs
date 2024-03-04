using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace workoutTracker.Domain.ViewModels
{
    public class LoginViewModel
    {
        // jwt token string
        [Required]
        [JsonPropertyName("Code")]
        public string Code { get; set; }
    }
}
