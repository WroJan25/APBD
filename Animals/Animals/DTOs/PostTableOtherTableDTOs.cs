using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium.DTOs;

public record PostDTORequest(
    [Required] [MaxLength(100)] string Field
 //   ICollection Lista
);

