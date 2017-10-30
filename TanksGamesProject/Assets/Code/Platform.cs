using UnityEngine;

namespace Assets.Code.Structure
{
    /// <summary>
    /// Represents a what platform (e.g. OS) we're running on
    /// </summary>
    public enum PlatformType {
        Windows,
        Mac,
        Linux,
    }

    /// <summary>
    /// Utilities for determining what platform (e.g. Mac vs Windows) we're running on.
    /// Determining the controller "axis" bindings for the particular platform we're on.
    /// This lets the rest of the game ignore whether we're running on Max or Windows.
    /// </summary>
    public static class Platform {
        public static PlatformType GetPlatform() {
            
            return PlatformType.Windows; 
        }

        public static string GetFireAxis(int player) {
            if (GetPlatform() == PlatformType.Windows) {
                return player == 1 ? "FireWindows" : "FireWindows2";
            }
            return player == 1 ? "FireMac" : "FireMac2";
            
        }
    }
}