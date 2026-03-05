using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dtos
{
    public record CallBackDataDto
    (
         string ConversationId,
         string Status,
         string Locale,
         string PaymentId,
         string MDStatus
     );
}
