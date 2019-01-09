using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoAPI.Models.Todo
{
    /// <summary>
    /// Class of TodoItem
    /// </summary>
    public class TodoItem
    {
        /// <summary>
        /// Unique Id of Item
        /// </summary>
        /// <value>UUID string</value>
        [StringLength(36)]
        public string Id { get; set; }
        
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        
        [StringLength(1000)]

        /// <summary>
        /// Description of item
        /// </summary>
        /// <value></value>
        public string Details { get; set; }
        [Required]
        
        /// <summary>
        /// Date to be started task
        /// </summary>
        /// <value></value>
        public DateTime StartDate { get; set; }
        [Required]
        
        /// <summary>
        /// Date to be expired task
        /// </summary>
        /// <value></value>
        public DateTime EndDate { get; set; }
        
        /// <summary>
        /// Mark task as completed
        /// </summary>
        /// <value></value>
        public bool IsDone { get; set; }
    }
}