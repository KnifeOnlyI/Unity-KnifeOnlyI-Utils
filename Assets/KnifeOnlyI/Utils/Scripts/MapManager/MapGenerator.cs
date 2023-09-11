using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JetBrains.Annotations;
using KnifeOnlyI.Utils.Rooms;
using UnityEngine;
using UnityEngine.Serialization;

namespace KnifeOnlyI.Utils.MapManager
{
    public enum TileContent
    {
        Empty,
        Excluded,
        Checkpoint,
        Spawn,
        Room,
        Corridor,
        CorridorL,
        CorridorT,
        CorridorX
    }

    public enum Direction
    {
        North,
        South,
        East,
        West
    }

    public class Tile
    {
        public int Line { get; set; }
        public int Column { get; set; }
        public string Name { get; set; }
        public TileContent Content { get; set; }
        public Direction Direction { get; set; }
    }

    public class MapGenerator : MonoBehaviour
    {
        private const int MapWidth = 6;
        private const int MapHeight = 6;

        private static readonly List<string> Checkpoints = new()
        {
            "EX-A", "EX-B"
        };

        private static readonly List<string> Spawns = new()
        {
            "Spawn"
        };

        private static readonly List<string> Rooms = new()
        {
            "SCP-173", "SCP-914", "SCP-005"
        };

        [FormerlySerializedAs("room")] [SerializeField]
        private GameObject roomPrefab;

        private readonly Random.Random _random = new(666);

        private void Awake()
        {
            var map = InitializeEmptyMap(MapWidth, MapHeight);

            PlaceCheckpoints(map, Checkpoints);
            PlaceSpawns(map, Spawns);
            PlaceRooms(map, Rooms);
            PlaceCorridors(map);
            LogMap(map);

            SpawnMap(map);
        }

        private void SpawnMap(IEnumerable<List<Tile>> map)
        {
            foreach (var line in map)
            {
                foreach (var tile in line)
                {
                    GameObject roomInstance = null;

                    if (tile.Content is TileContent.Room or TileContent.Checkpoint or TileContent.Spawn)
                    {
                        roomInstance = InstantiateRoom(tile);
                    }

                    RotateRoomAccordingTileDirection(roomInstance, tile);
                }
            }
        }

        private GameObject InstantiateRoom(Tile tile)
        {
            var roomInstance = Instantiate(
                roomPrefab,
                new Vector3(10 * tile.Line, 0, 10 * tile.Column),
                Quaternion.identity
            );

            var room = roomInstance.GetComponent<Room>();

            room.SetName(tile.Name);

            return roomInstance;
        }

        private static void RotateRoomAccordingTileDirection(GameObject room, Tile tile)
        {
            if (room == null) return;

            switch (tile.Direction)
            {
                case Direction.South:
                    room.transform.Rotate(new Vector3(0, 90, 0));
                    break;
                case Direction.West:
                    room.transform.Rotate(new Vector3(0, 180, 0));
                    break;
                case Direction.North:
                    room.transform.Rotate(new Vector3(0, 270, 0));
                    break;
                case Direction.East:
                default:
                    break;
            }
        }

        private static string ToTileDirectionStr(Tile tile)
        {
            return tile.Direction switch
            {
                Direction.North => "N",
                Direction.South => "S",
                Direction.East => "E",
                Direction.West => "W",
                _ => "N"
            };
        }

        private static string ToTileContentStr(Tile tile)
        {
            return tile.Content switch
            {
                TileContent.Empty => "E",
                TileContent.Excluded => "X",
                TileContent.Checkpoint => "C",
                TileContent.Spawn => "S",
                TileContent.Room => "R",
                TileContent.Corridor => "C",
                TileContent.CorridorL => "L",
                TileContent.CorridorT => "T",
                TileContent.CorridorX => "X",
                _ => "E"
            };
        }

        private static void LogMap(IEnumerable<List<Tile>> map)
        {
            var mapContent = new StringBuilder().AppendLine();

            foreach (var line in map)
            {
                var lineContent = new StringBuilder();

                foreach (var tile in line)
                {
                    lineContent.Append(ToTileContentStr(tile)).Append(ToTileDirectionStr(tile)).Append(" ");
                }

                lineContent.AppendLine();

                mapContent.Append(lineContent);
            }

            Debug.Log("Map : " + mapContent);
        }

        private static List<List<Tile>> GetMapCopy(IEnumerable<List<Tile>> map)
        {
            return map.Select(line => new List<Tile>(line)).ToList();
        }

        private static List<Tile> GetAvailableTilesForRoom(IReadOnlyList<List<Tile>> map)
        {
            var availableTilesForRoom = new List<Tile>();

            foreach (var line in map)
            {
                foreach (var tile in line)
                {
                    if (tile.Line == 0) continue;

                    if (tile.Content == TileContent.Empty && NbRoomsTileAround(map, tile) == 0)
                    {
                        availableTilesForRoom.Add(tile);
                    }
                }
            }

            return availableTilesForRoom;
        }

        private static void RefreshMapForExcludedTiles(IReadOnlyList<List<Tile>> map)
        {
            foreach (var line in map)
            {
                foreach (var tile in line)
                {
                    if (tile.Line == 0) continue;

                    if (tile.Content == TileContent.Empty && NbEmptyTileAround(map, tile) < 2)
                    {
                        var aroundTiles = GetAroundTiles(map, tile);

                        if (aroundTiles[0].Content != TileContent.Checkpoint)
                        {
                            tile.Content = TileContent.Excluded;
                        }
                    }
                }
            }
        }

        private static IEnumerable<Direction> GetAvailableDirections(IReadOnlyList<List<Tile>> map, Tile tile)
        {
            var emptyDirections = new List<Direction>();
            var aroundTiles = GetAroundTiles(map, tile);

            var northTile = aroundTiles[0];
            var southTile = aroundTiles[1];
            var eastTile = aroundTiles[2];
            var westTile = aroundTiles[3];

            if (IsEmpty(northTile))
            {
                emptyDirections.Add(Direction.North);
            }

            if (IsEmpty(southTile))
            {
                emptyDirections.Add(Direction.South);
            }

            if (IsEmpty(eastTile))
            {
                emptyDirections.Add(Direction.East);
            }

            if (IsEmpty(westTile))
            {
                emptyDirections.Add(Direction.West);
            }

            return emptyDirections;
        }

        private static bool IsEmpty(Tile tile)
        {
            return tile is { Content: TileContent.Empty };
        }

        private static List<Tile> GetAroundTiles(IReadOnlyList<List<Tile>> map, Tile tile)
        {
            var aroundTiles = new List<Tile>
            {
                GetTileAtNorth(map, tile),
                GetTileAtSouth(map, tile),
                GetTileAtEast(map, tile),
                GetTileAtWest(map, tile)
            };

            return aroundTiles;
        }

        private static int NbEmptyTileAround(IReadOnlyList<List<Tile>> map, Tile tile)
        {
            return GetAroundTiles(map, tile)
                .Count(t => t is { Content: TileContent.Empty });
        }

        private static int NbRoomsTileAround(IReadOnlyList<List<Tile>> map, Tile tile)
        {
            return GetAroundTiles(map, tile)
                .Count(t => t != null && t.Content != TileContent.Empty && t.Content != TileContent.Excluded);
        }

        [CanBeNull]
        private static Tile GetTileAtNorth(IReadOnlyList<List<Tile>> map, Tile tile)
        {
            return tile.Line > 0
                ? map[tile.Line - 1][tile.Column]
                : null;
        }

        [CanBeNull]
        private static Tile GetTileAtSouth(IReadOnlyList<List<Tile>> map, Tile tile)
        {
            return tile.Line < map.Count - 1
                ? map[tile.Line + 1][tile.Column]
                : null;
        }

        [CanBeNull]
        private static Tile GetTileAtEast(IReadOnlyList<List<Tile>> map, Tile tile)
        {
            return tile.Column < map[0].Count - 1
                ? map[tile.Line][tile.Column + 1]
                : null;
        }

        [CanBeNull]
        private static Tile GetTileAtWest(IReadOnlyList<List<Tile>> map, Tile tile)
        {
            return tile.Column > 0
                ? map[tile.Line][tile.Column - 1]
                : null;
        }

        private List<T> GetRandomElements<T>(IEnumerable<T> elements, int number)
        {
            var copy = new List<T>(elements);
            var pickedElements = new List<T>();

            for (var i = 0; i < number; i++)
            {
                var pickedElementIndex = _random.Next(0, copy.Count);
                var pickedElement = copy[pickedElementIndex];

                pickedElements.Add(pickedElement);
                copy.RemoveAt(pickedElementIndex);
            }

            return pickedElements;
        }

        private static List<List<Tile>> InitializeEmptyMap(int width, int height)
        {
            var map = new List<List<Tile>>();

            for (var i = 0; i < width; i++)
            {
                map.Add(new List<Tile>());

                for (var j = 0; j < height; j++)
                {
                    var tile = new Tile { Line = i, Column = j, Content = TileContent.Empty };

                    map[i].Add(tile);
                }
            }

            return map;
        }

        private void PlaceCheckpoints(IReadOnlyList<List<Tile>> map, IReadOnlyList<string> checkpoints)
        {
            var checkpointTiles = GetRandomElements(map[0], checkpoints.Count);

            for (var i = 0; i < checkpoints.Count; i++)
            {
                var checkpointTile = checkpointTiles[i];

                checkpointTile.Content = TileContent.Checkpoint;
                checkpointTile.Name = checkpoints[i];
                checkpointTile.Direction = Direction.South;
            }
        }

        private void PlaceSpawns(IReadOnlyList<List<Tile>> map, IReadOnlyList<string> spawns)
        {
            var spawnTiles = GetRandomElements(map[^1], spawns.Count);

            for (var i = 0; i < spawns.Count; i++)
            {
                var spawnTile = spawnTiles[i];

                spawnTile.Content = TileContent.Spawn;
                spawnTile.Name = spawns[i];
                spawnTile.Direction = GetRandomElements(GetAvailableDirections(map, spawnTile), 1)[0];
            }
        }

        private void PlaceRooms(IReadOnlyList<List<Tile>> map, List<string> rooms)
        {
            foreach (var room in rooms)
            {
                var availableTilesForRoom = GetAvailableTilesForRoom(map);

                if (availableTilesForRoom.Count == 0) return;

                var roomTile = GetRandomElements(availableTilesForRoom, 1)[0];

                roomTile.Content = TileContent.Room;
                roomTile.Name = room;
                roomTile.Direction = GetRandomElements(GetAvailableDirections(map, roomTile), 1)[0];
            }
        }

        private static void PlaceCorridors(IReadOnlyList<List<Tile>> map)
        {
            RefreshMapForExcludedTiles(map);
        }
    }
}