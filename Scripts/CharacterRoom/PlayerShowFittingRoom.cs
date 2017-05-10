using Spine;
using Spine.Unity;
using System.Collections;
using UnityEngine;
using Spine.Unity.Modules.AttachmentTools;

public class PlayerShowFittingRoom : MonoBehaviour
{
    #region Inspector
    [SpineAnimation]
    public string idle = "idle";
    [SpineAnimation]
    public string attack = "atk";

    [SpineEvent]
    public string EndAttackEvent = "EndAttack";


    [Header("From Sprite")]
    public Sprite[] swords;
    public string daggerName = "sword1";
    [SpineSlot]
    public string weaponSlot;

    #endregion
    private SkeletonAnimation skeletonAnimation;
    private int indexSword = 0;


    #region Controll phần đánh nhau
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.state.SetAnimation(0, idle, true);
        skeletonAnimation.state.Event += state_Event;
    }

    void state_Event(Spine.TrackEntry trackEntry, Spine.Event e)
    {
        if (e.data.name == EndAttackEvent)
        {
            skeletonAnimation.state.SetAnimation(0, idle, true);
        }
    }
    void OnMouseDown()
    {
        //cách 1
        skeletonAnimation.state.SetAnimation(1, attack, false);

        //cách 2
        //skeletonAnimation.AnimationName = attack;
    }
    #endregion
    #region Controll phần đổi skin

    bool girlSkin;
    //void Start()
    //{
    //    skeletonAnimation = GetComponent<SkeletonAnimation>();
    //    skeletonAnimation.state.SetAnimation(0, "walk", true);
    //}
    internal void ChangeSkin()
    {
        skeletonAnimation.Skeleton.SetSkin(girlSkin ? "goblin" : "goblingirl");
        skeletonAnimation.Skeleton.SetSlotsToSetupPose();
        girlSkin = !girlSkin;
        if (girlSkin)
        {
            skeletonAnimation.Skeleton.SetAttachment("right hand item", null);
            skeletonAnimation.Skeleton.SetAttachment("left hand item", "spear");
        }
        else
            skeletonAnimation.Skeleton.SetAttachment("left hand item", "dagger");
    }
    #endregion

    public void ChangeWeapon()
    {
        var skeleton = skeletonAnimation.Skeleton;
        var newSkin = skeleton.UnshareSkin(true, false, skeletonAnimation.AnimationState);

        // Case 2: Create an attachment from a Unity Sprite (Sprite texture needs to be Read/Write Enabled in the inspector.
        RegionAttachment newWeapon = swords[indexSword].ToRegionAttachmentPMAClone(Shader.Find("Spine/Skeleton"));
        daggerName = swords[indexSword].name;
        newWeapon.SetScale(0.7f, 0.7f);
        newWeapon.UpdateOffset();
        int weaponSlotIndex = skeleton.FindSlotIndex(weaponSlot);
        newSkin.AddAttachment(weaponSlotIndex, daggerName, newWeapon);

        skeleton.SetSkin(newSkin);
        skeleton.SetToSetupPose();
        skeleton.SetAttachment(weaponSlot, daggerName);

        Resources.UnloadUnusedAssets();

        indexSword++;
        if (indexSword > 2) indexSword = 0;
    }
    void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.X)) ChangeWeapon();
    }
}
