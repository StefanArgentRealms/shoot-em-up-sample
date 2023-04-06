using UnityEngine;

namespace Games.Scripts.Utility.Data
{
    //The idea with this class is that in a bigger project data would be easier to re-use between many different objects.
    //For example: instead of changing movement speeds of 10 different enemies in their prefabs, they could share a ScriptableObject and the designer just needs to change that single value.
    //It could also be expanded to being settable at runtime, in which case it can be used to communicate data across objects without them needing a direct reference to each other.
    //I use a similar approach in my own projects, but use Observables through UniRx together with a custom inspector to allow the same class of ScriptableObject to be used
    //either for editor-set data or runtime data.
    [CreateAssetMenu(menuName = "Shoot Em Up/Data/Float", fileName = "FloatData", order = 0)]
    public class FloatData : ScriptableObject
    {
        [SerializeField] private float value;

        public float Value => value;
    }
}