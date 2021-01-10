using System.Collections.Generic;

namespace Poseidon.Api.Models
{
    public class ErrorMessage
    {
        #region Properties

        /// <summary>
        ///     The individual errors that occurred.
        /// </summary>
        public ICollection<string> Errors { get; set; }

        /// <summary>
        ///     The error message.
        /// </summary>
        public string Message { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initalizes a new instance of <see cref="ErrorMessage" />.
        /// </summary>
        /// <param name="message">The error message</param>
        public ErrorMessage(string message)
        {
            Message = message;
        }

        /// <summary>
        ///     Initalizes a new instance of <see cref="ErrorMessage" />.
        /// </summary>
        /// <param name="message">The error message</param>
        /// <param name="errors">The individual errors</param>
        public ErrorMessage(string message, ICollection<string> errors) : this(message)
        {
            Errors = errors;
        }

        #endregion
    }
}