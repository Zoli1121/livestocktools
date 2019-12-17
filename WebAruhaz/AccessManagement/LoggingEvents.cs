//-----------------------------------------------------------------------
// <copyright file="LoggingEvents.cs" company="SzzEV">
//     SzzEV
// </copyright>
//-----------------------------------------------------------------------

namespace WebAruhaz.AccessManagement
{
    /// <summary>
    /// Defines the <see cref="LoggingEvents" />
    /// </summary>
    public class LoggingEvents
    {
        /// <summary>
        /// Defines the GenerateItems
        /// </summary>
        public const int GenerateItems = 10;

        /// <summary>
        /// Defines the ListItems
        /// </summary>
        public const int ListItems = 11;

        /// <summary>
        /// Defines the GetItem
        /// </summary>
        public const int GetItem = 12;

        /// <summary>
        /// Defines the InsertItem
        /// </summary>
        public const int InsertItem = 13;

        /// <summary>
        /// Defines the UpdateItem
        /// </summary>
        public const int UpdateItem = 14;

        /// <summary>
        /// Defines the DeleteItem
        /// </summary>
        public const int DeleteItem = 15;

        /// <summary>
        /// Defines the GetItemNotFound
        /// </summary>
        public const int GetItemNotFound = 402;

        /// <summary>
        /// Defines the UpdateItemNotFound
        /// </summary>
        public const int UpdateItemNotFound = 404;

        /// <summary>
        /// Defines the DeleteItemNotFound
        /// </summary>
        public const int DeleteItemNotFound = 405;
    }
}
