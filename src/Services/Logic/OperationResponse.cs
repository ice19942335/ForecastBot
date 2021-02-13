using System;
using System.Collections.Generic;

namespace Logic
{
    /// <summary>
    /// Represent operation response that contains information about fulfillment.
    /// </summary>
    public class OperationResponse
    {
        /// <summary>
        /// Indicates that operation was successfull.
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Error message.
        /// </summary>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Contains multiple error messages.
        /// </summary>
        public List<string> ErrorMessageList { get; set; }

        /// <summary>
        /// Additional information object.
        /// </summary>
        public Object ResponseData { get; set; }
    }
}
