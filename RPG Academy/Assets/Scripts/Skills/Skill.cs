
using Unity.Mathematics;
using UnityEngine;

public abstract class Skill : MonoBehaviour
{
    [Header("Base Skill")]
    public string skillName;
    public float animationDuration;
    
    public bool selflnflicted;
    
    public GameObject effectPrfb;
    
    protected Fighter emitter;
    protected Fighter receiver;

    private void Animate()
    {
        var go = Instantiate(this.effectPrfb, this.receiver.transform.position, quaternion.identity);
            Destroy(go, this. animationDuration) ;
    }

    public void Run()
    {
        if (this.selflnflicted)
        {
            this.receiver = this.emitter;
        }
    
            this.Animate();
            this.OnRun();
    }

    

    public void SetEmitterAndReceiver(Fighter _emitter, Fighter _receiver)
    {
        this.emitter = _emitter;
        this.receiver = _receiver;
    }
    protected abstract void OnRun();
}
       
   
