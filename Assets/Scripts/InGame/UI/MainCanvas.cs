using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCanvas : MonoBehaviour
{
    public HpContainer hpGauge;
    public SimpleGauge fuelGauge;
    public SimpleGauge guardGauge;

    public ScoreBox scoreBox;
    public WeaponStatus weaponStatus;
    public SimpleSkill healSkillGauge;
    public SimpleSkill bombSkillGauge;
    public CurrentFlight currentFlight;
}
