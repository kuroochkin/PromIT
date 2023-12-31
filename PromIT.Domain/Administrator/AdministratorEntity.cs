﻿namespace PromIT.Domain.Administrator;

public class AdministratorEntity
{
	public Guid Id { get; set; }

	public string Nickname { get; set; } = null!;

	public AdministratorEntity(Guid id, string nickname)
	{
		Id = id;
		Nickname = nickname;
	}
}
