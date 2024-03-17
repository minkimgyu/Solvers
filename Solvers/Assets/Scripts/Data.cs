using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Newtonsoft.Json;

namespace SOLVERS.DATA
{
    [Serializable]
    public class UserData
    {
        public string handle;
        public string bio;
        public string badgeId;
        public string backgroundId;
        public string profileImageUrl;
        public int solvedCount;
        public int voteCount;
        public int tier;
        public int rating;
        public int ratingByProblemsSum;

        public int ratingByClass;
        public int ratingBySolvedCount;
        public int ratingByVoteCount;

        [JsonProperty("class")]
        public int userClass;

        public string classDecoration;
        public int rivalCount;
        public int reverseRivalCount;
        public int maxStreak;
        public int coins;

        public int stardusts;
        public string joinedAt;
        public string bannedUntil;
        public string proUntil;
        public int rank;

        public bool isRival;
        public bool isReverseRival;
    }

    [Serializable]
    public class ProblemData
    {
        public ProblemData(int problemId, string titleKo, string rank, string date ) 
        { 
            this.problemId = problemId; 
            this.titleKo = titleKo; 
            this.rank = rank; 
            this.date = date; 
        }

        public int problemId;
        public string titleKo;
        public string rank;
        public string date;
    }

    [Serializable]
    public class RegisterData
    {
        public RegisterData(string userName, string registerDate)
        {
            this.userName = userName;
            this.registerDate = registerDate;
        }

        public string userName;
        public string registerDate;
    }

    public enum ORDER 
    {
        DELETEROW,
        INSERTROW,
        CHANGEROW,
        CONTAINROW,

        READSHEET,
        ADDSOLVEDDATA
    }

    [Serializable]
    public class BaseOrder
    {
        public BaseOrder(string type) { this.type = type; }

        public string type;
    }


    [Serializable]
    public class AppendSolvedDataOrder : BaseOrder
    {
        public AppendSolvedDataOrder(string userName) :base(ORDER.ADDSOLVEDDATA.ToString())
        {
            this.userName = userName;
        }

        public string userName;
    }

    [Serializable]
    public class SheetOrder : BaseOrder
    {
        public SheetOrder(string sheetName, string type) : base(type) { this.sheetName = sheetName; }

        public string sheetName;
    }

    [Serializable]
    public class ReadSheetOrder : SheetOrder
    {
        public ReadSheetOrder(string sheetName) : base(sheetName, ORDER.READSHEET.ToString())
        {
        }
    }

    [Serializable]
    public class ContainRowOrder : SheetOrder
    {
        public ContainRowOrder(string sheetName, string title, string value) : base(sheetName, ORDER.CONTAINROW.ToString())
        {
            this.title = title;
            this.value = value;
        }

        public string title;
        public string value;
    }

    [Serializable]
    abstract public class ModifySheetOrder : SheetOrder
    {
        public ModifySheetOrder(string sheetName, string type) : base(sheetName, type)
        {
        }
    }

    [Serializable]
    public class DeleteRowOrder : ModifySheetOrder
    {
        public DeleteRowOrder(string sheetName, string title, string value) : base(sheetName, ORDER.DELETEROW.ToString())
        {
            this.title = title;
            this.value = value;
        }

        public string title;
        public string value;
    }

    [Serializable]
    public class ChangeRowOrder : ModifySheetOrder
    {
        public ChangeRowOrder(string sheetName, string title, string beforeValue, string afterValue) : base(sheetName, ORDER.CHANGEROW.ToString())
        {
            this.title = title;
            this.beforeValue = beforeValue;
            this.afterValue = afterValue;
        }

        public string title;
        public string beforeValue;
        public string afterValue;
    }

    [Serializable]
    public class InsertRowOrder<T> : ModifySheetOrder
    {
        public T container;

        public InsertRowOrder(string sheetName, T data) : base(sheetName, ORDER.INSERTROW.ToString())
        {
            container = data;
        }
    }
}