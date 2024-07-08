using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoQuarry;

[Table("user")]
public class UserInfo{
    public long ID { get; set; }
    [Column("username")]
    public string? username { get; set; }
    [Column("password")]
    public string password { get; set; }
}