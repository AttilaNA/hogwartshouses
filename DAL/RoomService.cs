﻿namespace hogwartshouses;

public class RoomService : IRoomService
{
    private IRepository<Room> _repository { get; }

    public RoomService(IRepository<Room> repository)
    {
        _repository = repository;
    }

    public HashSet<Room> GetAllRooms()
    {
        return _repository.GetAll();
    }
}