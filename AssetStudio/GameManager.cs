﻿using System;
using System.Linq;
using System.Collections.Generic;
using static AssetStudio.Crypto;

namespace AssetStudio
{
    public static class GameManager
    {
        private static Dictionary<int, Game> Games = new Dictionary<int, Game>();
        static GameManager()
        {
            int index = 0;
            Games.Add(index++, new(GameType.一般的));
            Games.Add(index++, new(GameType.UnityCN));
            Games.Add(index++, new Mhy(GameType.原神, GIMhyShiftRow, GIMhyKey, GIMhyMul, GIExpansionKey, GISBox, GIInitVector, GIInitSeed));
            Games.Add(index++, new Mr0k(GameType.原神_Pack, PackExpansionKey, blockKey: PackBlockKey));
            Games.Add(index++, new Mr0k(GameType.原神_CB1));
            Games.Add(index++, new Blk(GameType.原神_CB2, GI_CBXExpansionKey, initVector: GI_CBXInitVector, initSeed: GI_CBXInitSeed));
            Games.Add(index++, new Blk(GameType.原神_CB3, GI_CBXExpansionKey, initVector: GI_CBXInitVector, initSeed: GI_CBXInitSeed));
            Games.Add(index++, new Mhy(GameType.原神_CB3Pre, GI_CBXMhyShiftRow, GI_CBXMhyKey, GI_CBXMhyMul, GI_CBXExpansionKey, GI_CBXSBox, GI_CBXInitVector, GI_CBXInitSeed));
            Games.Add(index++, new Mr0k(GameType.崩坏3, BH3ExpansionKey, BH3SBox, BH3InitVector, BH3BlockKey));
            Games.Add(index++, new Mr0k(GameType.崩坏3Pre, PackExpansionKey, blockKey: PackBlockKey));
            Games.Add(index++, new Mr0k(GameType.崩坏3PrePre, PackExpansionKey, blockKey: PackBlockKey));
            Games.Add(index++, new Mr0k(GameType.崩坏星穹铁道_CB2, Mr0kExpansionKey, initVector: Mr0kInitVector, blockKey: Mr0kBlockKey));
            Games.Add(index++, new Mr0k(GameType.崩坏星穹铁道, Mr0kExpansionKey, initVector: Mr0kInitVector, blockKey: Mr0kBlockKey));
            Games.Add(index++, new Mr0k(GameType.绝区零_CB1, Mr0kExpansionKey, initVector: Mr0kInitVector, blockKey: Mr0kBlockKey));
            Games.Add(index++, new Mr0k(GameType.践踏之塔, Mr0kExpansionKey, initVector: Mr0kInitVector, blockKey: Mr0kBlockKey, postKey: ToTKey));
            Games.Add(index++, new Game(GameType.永劫无间));
            Games.Add(index++, new Game(GameType.偶像梦幻祭));
            Games.Add(index++, new Game(GameType.OPFP));
            Games.Add(index++, new Game(GameType.FakeHeader));
            Games.Add(index++, new Game(GameType.FantasyOfWind));
            Games.Add(index++, new Game(GameType.ShiningNikki));
            Games.Add(index++, new Game(GameType.HelixWaltz2));
            Games.Add(index++, new Game(GameType.NetEase));
            Games.Add(index++, new Game(GameType.AnchorPanic));
            Games.Add(index++, new Game(GameType.DreamscapeAlbireo));
            Games.Add(index++, new Game(GameType.ImaginaryFest));
            Games.Add(index++, new Game(GameType.AliceGearAegis));
            Games.Add(index++, new Game(GameType.ProjectSekai));
            Games.Add(index++, new Game(GameType.CodenameJump));
            Games.Add(index++, new Game(GameType.GirlsFrontline));
            Games.Add(index++, new Game(GameType.Reverse1999));
            Games.Add(index++, new Game(GameType.ArknightsEndfield));
            Games.Add(index++, new Game(GameType.JJKPhantomParade));
            Games.Add(index++, new Game(GameType.MuvLuvDimensions));
            Games.Add(index++, new Game(GameType.PartyAnimals));
            Games.Add(index++, new Game(GameType.LoveAndDeepspace));
            Games.Add(index++, new Game(GameType.SchoolGirlStrikers));
            Games.Add(index++, new Game(GameType.ExAstris));
            Games.Add(index++, new Game(GameType.PerpetualNovelty));
        }
        public static Game GetGame(GameType gameType) => GetGame((int)gameType);
        public static Game GetGame(int index)
        {
            if (!Games.TryGetValue(index, out var format))
            {
                throw new ArgumentException("Invalid format !!");
            }

            return format;
        }

        public static Game GetGame(string name) => Games.FirstOrDefault(x => x.Value.Name == name).Value;
        public static Game[] GetGames() => Games.Values.ToArray();
        public static string[] GetGameNames() => Games.Values.Select(x => x.Name).ToArray();
        public static string SupportedGames() => $"Supported Games:\n{string.Join("\n", Games.Values.Select(x => x.Name))}";
    }

    public record Game
    {
        public string Name { get; set; }
        public GameType Type { get; }

        public Game(GameType type)
        {
            Name = type.ToString();
            Type = type;
        }

        public sealed override string ToString() => Name;
    }

    public record Mr0k : Game
    {
        public byte[] ExpansionKey { get; }
        public byte[] SBox { get; }
        public byte[] InitVector { get; }
        public byte[] BlockKey { get; }
        public byte[] PostKey { get; }

        public Mr0k(GameType type, byte[] expansionKey = null, byte[] sBox = null, byte[] initVector = null, byte[] blockKey = null, byte[] postKey = null) : base(type)
        {
            ExpansionKey = expansionKey ?? Array.Empty<byte>();
            SBox = sBox ?? Array.Empty<byte>();
            InitVector = initVector ?? Array.Empty<byte>();
            BlockKey = blockKey ?? Array.Empty<byte>();
            PostKey = postKey ?? Array.Empty<byte>();
        }
    }

    public record Blk : Game
    {
        public byte[] ExpansionKey { get; }
        public byte[] SBox { get; }
        public byte[] InitVector { get; }
        public ulong InitSeed { get; }

        public Blk(GameType type, byte[] expansionKey = null, byte[] sBox = null, byte[] initVector = null, ulong initSeed = 0) : base(type)
        {
            ExpansionKey = expansionKey ?? Array.Empty<byte>();
            SBox = sBox ?? Array.Empty<byte>();
            InitVector = initVector ?? Array.Empty<byte>();
            InitSeed = initSeed;
        }
    }

    public record Mhy : Blk
    {
        public byte[] MhyShiftRow { get; }
        public byte[] MhyKey { get; }
        public byte[] MhyMul { get; }

        public Mhy(GameType type, byte[] mhyShiftRow, byte[] mhyKey, byte[] mhyMul, byte[] expansionKey = null, byte[] sBox = null, byte[] initVector = null, ulong initSeed = 0) : base(type, expansionKey, sBox, initVector, initSeed)
        {
            MhyShiftRow = mhyShiftRow;
            MhyKey = mhyKey;
            MhyMul = mhyMul;
        }
    }

    public enum GameType
    {
        一般的,
        UnityCN,
        原神,
        原神_Pack,
        原神_CB1,
        原神_CB2,
        原神_CB3,
        原神_CB3Pre,
        崩坏3,
        崩坏3Pre,
        崩坏3PrePre,
        绝区零_CB1,
        崩坏星穹铁道_CB2,
        崩坏星穹铁道,
        践踏之塔,
        永劫无间,
        偶像梦幻祭,
        OPFP,
        FakeHeader,
        FantasyOfWind,
        ShiningNikki,
        HelixWaltz2,
        NetEase,
        AnchorPanic,
        DreamscapeAlbireo,
        ImaginaryFest,
        AliceGearAegis,
        ProjectSekai,
        CodenameJump,
        GirlsFrontline,
        Reverse1999,
        ArknightsEndfield,
        JJKPhantomParade,
        MuvLuvDimensions,
        PartyAnimals,
        LoveAndDeepspace,
        SchoolGirlStrikers,
        ExAstris,
        PerpetualNovelty,
    }

    public static class GameTypes
    {
        public static bool IsNormal(this GameType type) => type == GameType.一般的;
        public static bool IsUnityCN(this GameType type) => type == GameType.UnityCN;
        public static bool IsGI(this GameType type) => type == GameType.原神;
        public static bool IsGIPack(this GameType type) => type == GameType.原神_Pack;
        public static bool IsGICB1(this GameType type) => type == GameType.原神_CB1;
        public static bool IsGICB2(this GameType type) => type == GameType.原神_CB2;
        public static bool IsGICB3(this GameType type) => type == GameType.原神_CB3;
        public static bool IsGICB3Pre(this GameType type) => type == GameType.原神_CB3Pre;
        public static bool IsBH3(this GameType type) => type == GameType.崩坏3;
        public static bool IsBH3Pre(this GameType type) => type == GameType.崩坏3Pre;
        public static bool IsBH3PrePre(this GameType type) => type == GameType.崩坏3PrePre;
        public static bool IsZZZCB1(this GameType type) => type == GameType.绝区零_CB1;
        public static bool IsSRCB2(this GameType type) => type == GameType.崩坏星穹铁道_CB2;
        public static bool IsSR(this GameType type) => type == GameType.崩坏星穹铁道;
        public static bool IsTOT(this GameType type) => type == GameType.践踏之塔;
        public static bool IsNaraka(this GameType type) => type == GameType.永劫无间;
        public static bool IsOPFP(this GameType type) => type == GameType.OPFP;
        public static bool IsNetEase(this GameType type) => type == GameType.NetEase;
        public static bool IsArknightsEndfield(this GameType type) => type == GameType.ArknightsEndfield;
        public static bool IsLoveAndDeepspace(this GameType type) => type == GameType.LoveAndDeepspace;
        public static bool IsExAstris(this GameType type) => type == GameType.ExAstris;
        public static bool IsPerpetualNovelty(this GameType type) => type == GameType.PerpetualNovelty;
        public static bool IsGIGroup(this GameType type) => type switch
        {
            GameType.原神 or GameType.原神_Pack or GameType.原神_CB1 or GameType.原神_CB2 or GameType.原神_CB3 or GameType.原神_CB3Pre => true,
            _ => false,
        };

        public static bool IsGISubGroup(this GameType type) => type switch
        {
            GameType.原神 or GameType.原神_CB2 or GameType.原神_CB3 or GameType.原神_CB3Pre => true,
            _ => false,
        };

        public static bool IsBH3Group(this GameType type) => type switch
        {
            GameType.崩坏3 or GameType.崩坏3Pre => true,
            _ => false,
        };

        public static bool IsSRGroup(this GameType type) => type switch
        {
            GameType.崩坏星穹铁道_CB2 or GameType.崩坏星穹铁道 => true,
            _ => false,
        };

        public static bool IsBlockFile(this GameType type) => type switch
        {
            GameType.崩坏3 or GameType.崩坏3Pre or GameType.崩坏星穹铁道 or GameType.原神_Pack or GameType.践踏之塔 or GameType.ArknightsEndfield => true,
            _ => false,
        };

        public static bool IsMhyGroup(this GameType type) => type switch
        {
            GameType.原神 or GameType.原神_Pack or GameType.原神_CB1 or GameType.原神_CB2 or GameType.原神_CB3 or GameType.原神_CB3Pre or GameType.崩坏3 or GameType.崩坏3Pre or GameType.崩坏3PrePre or GameType.崩坏星穹铁道_CB2 or GameType.崩坏星穹铁道 or GameType.绝区零_CB1 or GameType.践踏之塔 => true,
            _ => false,
        };
    }
}
