# App Identification
*Version: 1.3.0*
## Description: 
A library for managing app identifiers and different release variants.
## Package Mirrors: 
[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODg3LnBuZw==/original/npRUfq.png'>](https://github.com/Iron-Mountain-Software/app-identification)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODkyLnBuZw==/original/Fq0ORM.png'>](https://www.npmjs.com/package/com.iron-mountain.app-identification)[<img src='https://img.itch.zone/aW1nLzEzNzQ2ODk4LnBuZw==/original/Rv4m96.png'>](https://iron-mountain.itch.io/app-identification)
---
## Key Scripts & Components: 
1. public struct **AppLogos**
   * Properties: 
      * public Sprite ***HorizontalLight***  { get; }
      * public Sprite ***HorizontalDark***  { get; }
      * public Sprite ***SquareLight***  { get; }
      * public Sprite ***SquareDark***  { get; }
   * Methods: 
      * public Sprite ***GetLogo***(Type type)
1. public class **AppReleaseVariantDependantGameObject** : MonoBehaviour
   * Methods: 
      * public void ***Refresh***()
1. public static class **AppReleaseVariantsManager**
1. public class **ApplicationIdentifiers**
   * Properties: 
      * public String ***Fallback***  { get; }
      * public String ***IOS***  { get; }
      * public String ***Android***  { get; }
   * Methods: 
      * public Boolean ***Contains***(String identifier)
1. public class **Database** : ScriptableObject
   * Properties: 
      * public List<ScriptedAppReleaseVariant> ***AppReleaseVariants***  { get; }
   * Methods: 
      * public ScriptedAppReleaseVariant ***GetReleaseVariantByID***(String id)
      * public void ***SortList***()
      * public void ***RebuildDictionary***()
      * public override String ***ToString***()
1. public interface **IAppReleaseVariant**
   * Properties: 
      * public String ***ID***  { get; }
      * public String ***ProductName***  { get; }
      * public ApplicationIdentifiers ***ApplicationIdentifiers***  { get; }
      * public Texture2D ***Icon***  { get; }
      * public AppLogos ***Logos***  { get; }
   * Methods: 
      * public abstract String ***ToString***()
      * public abstract void ***Activate***()
      * public abstract void ***Deactivate***()
1. public class **ScriptedAppReleaseVariant** : ScriptableObject
   * Properties: 
      * public String ***ID***  { get; }
      * public String ***ProductName***  { get; }
      * public ApplicationIdentifiers ***ApplicationIdentifiers***  { get; }
      * public Texture2D ***Icon***  { get; }
      * public AppLogos ***Logos***  { get; }
   * Methods: 
      * public override String ***ToString***()
      * public virtual void ***Activate***()
      * public virtual void ***Deactivate***()
      * public virtual void ***Reset***()
### U I
1. public class **AppLogoImage** : MonoBehaviour
1. public class **ApplicationIdentifierText** : MonoBehaviour
1. public class **ApplicationVersionText** : MonoBehaviour
1. public class **DeviceUniqueIdentifierText** : MonoBehaviour
