using TowerDefenseNetworking.TypeEnums;

namespace TowerDefenseNetworking
{
    /// <summary>
    /// The player do the action such as to build the tower,upgrad that tower or destory, so this struct
    /// wrap all information about that action.
    /// </summary>
    public struct TowerAction
    {
        public Point Location { get; set; }
        public TowerActionTypes TowerActionType { get; set; }
        public TowerTypes TowerType { get; set; }
        public PlayerID PlayerID { get; set; }
    }
}
