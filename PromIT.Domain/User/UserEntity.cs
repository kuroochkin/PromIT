namespace PromIT.Domain.User;

public class UserEntity
{
	public Guid Id { get; set; }

	public string Nickname { get; set; } = null!;

	public string Password { get; set; } = null!;

	public UserEntity(string nickname, string password)
	{
		Id = Guid.NewGuid();
		Nickname = nickname;
		Password = password;
	}
}
