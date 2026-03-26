namespace workoutTracker.Domain.ViewModels
{
    public class TagGroupViewModel
    {
        public string TagType { get; set; }
        public IList<TagViewModel> Tags { get; set; }
        public IList<TagGroupViewModel>? TagGroups { get; set; }
    }
}
