using System;
using System.Text;

namespace Securify.ShellLink.Structures
{
    /// <summary>
    /// Abstract Structure class
    /// </summary>
    public abstract class Structure
    {
        /// <summary>
        /// Convert the Structure to a byte array
        /// </summary>
        /// <returns>Byte array representation of the Structure</returns>
        public abstract byte[] GetBytes();

        /// <inheritdoc />
        public override String ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("{0}:", this.GetType().Name);
            builder.AppendLine();
            return builder.ToString();
        }
    }
}
