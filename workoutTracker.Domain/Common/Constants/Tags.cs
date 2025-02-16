using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace workoutTracker.Domain.Common.Constants
{
    public static class Tags
    {
        // Miscellanous
        public static readonly Guid Miscellanous_Alternating = Guid.Parse("1cfe3f65-ef2f-4646-b4d0-5f3e312bdd5f");
        public static readonly Guid Miscellanous_Chest_Lower = Guid.Parse("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd60");
        public static readonly Guid Miscellanous_Chest_Middle = Guid.Parse("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd61");
        public static readonly Guid Miscellanous_Chest_Upper = Guid.Parse("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd62");
        public static readonly Guid Miscellanous_Mobility = Guid.Parse("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd63");
        public static readonly Guid Miscellanous_Rehab = Guid.Parse("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd64");
        public static readonly Guid Miscellanous_Unilateral = Guid.Parse("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd65");
        public static readonly Guid Miscellanous_Warmup = Guid.Parse("5b3e3f65-ef2f-4646-b4d0-5f3e312bdd66");
        public static readonly Guid Miscellaneous_PPL_Push = Guid.Parse("11ce3f65-ef2f-4646-b4d0-5f3e312bdd5e");
        public static readonly Guid Miscellaneous_PPL_Pull = Guid.Parse("133e3f65-ef2f-4646-b4d0-5f3e312bdd5f");
        public static readonly Guid Miscellaneous_PPL_Legs = Guid.Parse("1b663f65-ef2f-4646-b4d0-5f3e312bdd60");

        // Discipline
        public static readonly Guid Discipline_Bodybuilding = Guid.Parse("333e3f65-ef2f-4646-b4d0-5f3e312bdd5e");
        public static readonly Guid Discipline_Crossfit = Guid.Parse("666e3f65-ef2f-4646-b4d0-5f3e312bdd5f");
        public static readonly Guid Discipline_Powerlifting = Guid.Parse("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd60");
        public static readonly Guid Discipline_Strongman = Guid.Parse("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd61");
        public static readonly Guid Discipline_Weightlifting = Guid.Parse("6b3e3f65-ef2f-4646-b4d0-5f3e312bdd62");

        // Muscle Activation Pattern
        public static readonly Guid MuscleActivationPattern_Complex = Guid.Parse("444e3f65-ef2f-4646-b4d0-5f3e312bdd5e");
        public static readonly Guid MuscleActivationPattern_Compound = Guid.Parse("0b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f");
        public static readonly Guid MuscleActivationPattern_Isolation = Guid.Parse("055e3f65-ef2f-4646-b4d0-5f3e312bdd60");


        // Body Zone
        public static readonly Guid BodyZone_UpperBody = Guid.Parse("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f");
        public static readonly Guid BodyZone_LowerBody = Guid.Parse("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd50");
        public static readonly Guid BodyZone_Core = Guid.Parse("8b3e3f65-ef2f-4646-b4d0-5f3e312bdd51");


        // Muscle Family
        public static readonly Guid MuscleFamily_Calves = Guid.Parse("25553f65-ef2f-4646-b4d0-5f3e312bdd5e");
        public static readonly Guid MuscleFamily_Chest = Guid.Parse("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f");
        public static readonly Guid MuscleFamily_Forearms = Guid.Parse("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd60");
        public static readonly Guid MuscleFamily_LowerBack = Guid.Parse("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd61");
        public static readonly Guid MuscleFamily_Neck = Guid.Parse("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd62");
        public static readonly Guid MuscleFamily_Shoulders = Guid.Parse("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd63");
        public static readonly Guid MuscleFamily_Thighs = Guid.Parse("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd64");
        public static readonly Guid MuscleFamily_UpperArms = Guid.Parse("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd65");
        public static readonly Guid MuscleFamily_UpperBack = Guid.Parse("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd66");
        public static readonly Guid MuscleFamily_Abdominals = Guid.Parse("2b3e3f65-ef2f-4646-b4d0-5f3e312bdd67");

        // Muscle Group
        public static readonly Guid MuscleGroup_Adductors = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd11");
        public static readonly Guid MuscleGroup_Biceps = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd5e");
        public static readonly Guid MuscleGroup_CalvesGastroc = Guid.Parse("752e3f65-ef2f-4646-b4d0-5f3e312bdd5f");
        public static readonly Guid MuscleGroup_CalvesSoleus = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd60");
        public static readonly Guid MuscleGroup_CalvesTibialis = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd61");
        public static readonly Guid MuscleGroup_ForearmExtensors = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd62");
        public static readonly Guid MuscleGroup_ForearmFlexors = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd63");
        public static readonly Guid MuscleGroup_FrontDelts = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd64");
        public static readonly Guid MuscleGroup_Glutes = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd65");
        public static readonly Guid MuscleGroup_Hamstrings = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd66");
        public static readonly Guid MuscleGroup_Lats = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd67");
        public static readonly Guid MuscleGroup_Pecs = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd68");
        public static readonly Guid MuscleGroup_Obliques = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd5f");
        public static readonly Guid MuscleGroup_Quads = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd69");
        public static readonly Guid MuscleGroup_RearDelts = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6a");
        public static readonly Guid MuscleGroup_Abs = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6f");
        public static readonly Guid MuscleGroup_SideDelts = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6b");
        public static readonly Guid MuscleGroup_Traps = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6c");
        public static readonly Guid MuscleGroup_Triceps = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6d");
        public static readonly Guid MuscleGroup_SpinalErectors = Guid.Parse("7b3e3f65-ef2f-4646-b4d0-5f3e312bdd6e");

        // Movement Pattern
        public static readonly Guid MovementPattern_Ankle_Dorsiflexion = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3301");
        public static readonly Guid MovementPattern_Ankle_Plantarflexion = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3302");
        public static readonly Guid MovementPattern_ArmAbduction_Horizontal = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3303");
        public static readonly Guid MovementPattern_ArmAbduction_Vertical = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3304");
        public static readonly Guid MovementPattern_ArmAdduction_Horizontal = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3305");
        public static readonly Guid MovementPattern_ArmAdduction_Vertical = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3306");
        public static readonly Guid MovementPattern_DeadliftPattern = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3307");
        public static readonly Guid MovementPattern_Elbow_Extension = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3308");
        public static readonly Guid MovementPattern_Elbow_Flexion = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3309");
        public static readonly Guid MovementPattern_Elbow_IsolatedFlexion = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3310");
        public static readonly Guid MovementPattern_Elbow_OverheadExtension = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3311");
        public static readonly Guid MovementPattern_HipHingePattern = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3312");
        public static readonly Guid MovementPattern_Hip_Abduction = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3313");
        public static readonly Guid MovementPattern_Hip_Adduction = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3314");
        public static readonly Guid MovementPattern_Hip_Extension = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3315");
        public static readonly Guid MovementPattern_Hip_Flexion = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3316");
        public static readonly Guid MovementPattern_Knee_Extension = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3317");
        public static readonly Guid MovementPattern_Knee_Flexion = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3318");
        public static readonly Guid MovementPattern_Pull_Horizontal = Guid.Parse("378504e0-4f89-11d3-9a0c-0305e82c3319");
        public static readonly Guid MovementPattern_Pull_Incline = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3320");
        public static readonly Guid MovementPattern_Pull_Upright = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3321");
        public static readonly Guid MovementPattern_Pull_Vertical = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3322");
        public static readonly Guid MovementPattern_Push_Decline = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3323");
        public static readonly Guid MovementPattern_Push_Horizontal = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3324");
        public static readonly Guid MovementPattern_Push_Incline = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3325");
        public static readonly Guid MovementPattern_Push_Vertical = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3326");
        public static readonly Guid MovementPattern_SquatPattern = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3327");
        public static readonly Guid MovementPattern_Wrist_Extension = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3328");
        public static readonly Guid MovementPattern_Wrist_Flexion = Guid.Parse("3f2504e0-4f89-11d3-9a0c-0305e82c3329");


        // Equipment
        public static readonly Guid Equipment_Barbell = Guid.Parse("4f2504e0-4f89-11d3-9a0c-0305e82c3301");
        public static readonly Guid Equipment_Cable = Guid.Parse("4f2504e0-4f89-11d3-9a0c-0305e82c3302");
        public static readonly Guid Equipment_Dumbbell = Guid.Parse("4f2504e0-4f89-11d3-9a0c-0305e82c3303");
        public static readonly Guid Equipment_Kettlebell = Guid.Parse("4f2504e0-4f89-11d3-9a0c-0305e82c3304");
        public static readonly Guid Equipment_Machine = Guid.Parse("4f2504e0-4f89-11d3-9a0c-0305e82c3305");
        public static readonly Guid Equipment_NoEquipment = Guid.Parse("4f2504e0-4f89-11d3-9a0c-0305e82c3306");


    }
}
