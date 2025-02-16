namespace workoutTracker.Domain.Common.Enums
{
    public enum TagType : int
    {
        /*
            TagType Enum Definitions:
            - Miscelaneous: 0
            - Discipline: 1, includes powerlifting, weightlifting, bodybuilding, endurance/cardio, crossift, strongman, athleticism, etc.
            - MuscleActivationPattern: 2, can be compound or isolation
            - UpperLower: 3, indicates whether the exercise is for the upper or lower body
            - PushPullLegs: 4, categorizes exercises into push, pull, or legs
            - MuscleFamily: 5, includes upper back, lower back, shoulders, chest, etc.
            - MuscleGroup: 6, includes lats, biceps, upper chest, lower chest, etc.
            - MovementVariation: 7, includes vertical pull, horizontal pull, etc.
            - ExerciseVariation: 8, includes pullup, pushdown (pullup would be applied to underhand and overhand pullups but not pulldowns)

            Hierarchy of TagTypes:
            ExerciseVariation > MovementVariation > MuscleGroup > MuscleFamily > Pattern > Discipline
         */
        Miscelaneous = 0,
        Discipline = 1,
        MuscleActivationPattern = 2,
        UpperLower = 3,
        PushPullLegs = 4,
        MuscleFamily = 5,
        MuscleGroup = 6,
        MovementPattern = 7,
    }
}
