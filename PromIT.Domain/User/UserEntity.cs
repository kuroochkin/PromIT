namespace PromIT.Domain.User;

public class UserEntity
{
	public Guid Id { get; set; }

	public string Nickname { get; set; } = null!;

	public string Password { get; set; } = null!;

	public UserType Type { get; }

	public UserType GetTypeUser => Type;

	public string GetUserTypeToString()
	{
		switch (Type)
		{
			case UserType.Reviewer:
				return "Reviewer";
			case UserType.Administrator:
				return "Administrator";
		}

		return "";
	}

	public UserEntity(string nickname, string password)
	{
		Id = Guid.NewGuid();
		Nickname = nickname;
		Password = password;
	}

	public enum UserType
	{
		Reviewer,
		Administrator
	}
}
