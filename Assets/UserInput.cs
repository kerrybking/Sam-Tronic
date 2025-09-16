using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class UserInput : MonoBehaviour
{
    [SerializeField] TMP_InputField userInput;
    [SerializeField] PlayerController playerController;
    [SerializeField] GameObject pcCmd;
    public GameObject mobileCmdPortrait;
    public GameObject mobileCmdLandscape;
    public GameObject mobileKeyboardPortrait;
    public GameObject mobileKeyboardLandscape;
    [SerializeField] BrickButton brickButton;
    [SerializeField] BrickButton brickButton2;
    public Button Q;
    public Button W;
    public Button E;
    public Button R;
    public Button T;
    public Button Y;
    public Button U;
    public Button I;
    public Button O;
    public Button P;
    public Button A;
    public Button S;
    public Button D;
    public Button F;
    public Button G;
    public Button H;
    public Button J;
    public Button K;
    public Button L;
    public Button Z;
    public Button X;
    public Button C;
    public Button V;
    public Button B;
    public Button N;
    public Button M;
    public Button Enter;
    public Button Space;
    public Button Shift;
    public Button Cross;


    public bool Captital;

    void AddListeners()
    {
        Q.onClick.AddListener(QKey);
        Shift.onClick.AddListener(ShiftKey);
        W.onClick.AddListener(WKey);
        E.onClick.AddListener(EKey);
        R.onClick.AddListener(RKey);
        T.onClick.AddListener(TKey);
        Y.onClick.AddListener(YKey);
        U.onClick.AddListener(UKey);
        I.onClick.AddListener(IKey);
        O.onClick.AddListener(OKey);
        P.onClick.AddListener(PKey);
        A.onClick.AddListener(AKey);
        S.onClick.AddListener(SKey);
        D.onClick.AddListener(DKey);
        F.onClick.AddListener(FKey);
        G.onClick.AddListener(GKey);
        H.onClick.AddListener(HKey);
        J.onClick.AddListener(JKey);
        K.onClick.AddListener(KKey);
        L.onClick.AddListener(LKey);
        Z.onClick.AddListener(ZKey);
        X.onClick.AddListener(XKey);
        C.onClick.AddListener(CKey);
        V.onClick.AddListener(VKey);
        B.onClick.AddListener(BKey);
        N.onClick.AddListener(NKey);
        M.onClick.AddListener(MKey);
        Cross.onClick.AddListener(CrossKey);
        Enter.onClick.AddListener(EnterKey);
        Space.onClick.AddListener(SpaceKey);

    }
    void RemoveListeners()
    {
        Q.onClick.RemoveListener(QKey);
        Shift.onClick.RemoveListener(ShiftKey);
        W.onClick.RemoveListener(WKey);
        E.onClick.RemoveListener(EKey);
        R.onClick.RemoveListener(RKey);
        T.onClick.RemoveListener(TKey);
        Y.onClick.RemoveListener(YKey);
        U.onClick.RemoveListener(UKey);
        I.onClick.RemoveListener(IKey);
        O.onClick.RemoveListener(OKey);
        P.onClick.RemoveListener(PKey);
        A.onClick.RemoveListener(AKey);
        S.onClick.RemoveListener(SKey);
        D.onClick.RemoveListener(DKey);
        F.onClick.RemoveListener(FKey);
        G.onClick.RemoveListener(GKey);
        H.onClick.RemoveListener(HKey);
        J.onClick.RemoveListener(JKey);
        K.onClick.RemoveListener(KKey);
        L.onClick.RemoveListener(LKey);
        Z.onClick.RemoveListener(ZKey);
        X.onClick.RemoveListener(XKey);
        C.onClick.RemoveListener(CKey);
        V.onClick.RemoveListener(VKey);
        B.onClick.RemoveListener(BKey);
        N.onClick.RemoveListener(NKey);
        M.onClick.RemoveListener(MKey);
        Cross.onClick.RemoveListener(CrossKey);
        Enter.onClick.RemoveListener(EnterKey);
        Space.onClick.RemoveListener(SpaceKey);
    }

    private void QKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if(Captital)
        {
            userInput.text += "Q";
            
        }
        else
        {
            userInput.text += "q";
        }

   

    }
    private void WKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "W";
        }
        else
        {
            userInput.text += "w";
        }

    }
    private void EKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "E";
        }
        else
        {
            userInput.text += "e";
        }

    }
    private void RKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "R";
        }
        else
        {
            userInput.text += "r";
        }

    }
    private void TKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "T";
        }
        else
        {
            userInput.text += "t";
        }

    }
    private void YKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "Y";
        }
        else
        {
            userInput.text += "y";
        }

    }
    private void UKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "U";
        }
        else
        {
            userInput.text += "u";
        }

    }
    private void IKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "I";
        }
        else
        {
            userInput.text += "i";
        }

    }
    private void OKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "O";
        }
        else
        {
            userInput.text += "o";
        }

    }
    private void PKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "P";
        }
        else
        {
            userInput.text += "p";
        }

    }
    private void AKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "A";
        }
        else
        {
            userInput.text += "a";
        }

    }
    private void SKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "S";
        }
        else
        {
            userInput.text += "s";
        }

    }
    private void DKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "D";
        }
        else
        {
            userInput.text += "d";
        }

    }
    private void FKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "F";
        }
        else
        {
            userInput.text += "f";
        }

    }
    private void GKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "G";
        }
        else
        {
            userInput.text += "g";
        }

    }
    private void HKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "H";
        }
        else
        {
            userInput.text += "h";
        }

    }
    private void JKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "J";
        }
        else
        {
            userInput.text += "j";
        }

    }
    private void KKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "K";
        }
        else
        {
            userInput.text += "k";
        }

    }
    private void LKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "L";
        }
        else
        {
            userInput.text += "l";
        }

    }
    private void ZKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "Z";
        }
        else
        {
            userInput.text += "z";
        }

    }
    private void XKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "X";
        }
        else
        {
            userInput.text += "x";
        }

    }
    private void CKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "C";
        }
        else
        {
            userInput.text += "c";
        }

    }
    private void VKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "V";
        }
        else
        {
            userInput.text += "v";
        }

    }
    private void BKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "B";
        }
        else
        {
            userInput.text += "b";
        }

    }
    private void NKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "N";
        }
        else
        {
            userInput.text += "n";
        }

    }
    private void MKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        if (Captital)
        {
            userInput.text += "M";
        }
        else
        {
            userInput.text += "m";
        }

    }
    private void SpaceKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

            userInput.text += " ";
        
    }
    private void ShiftKey()
    {
        if (userInput.text.Length > userInput.characterLimit)
            return;

        Captital = !Captital;

    }
    private void CrossKey()
    {
       if(userInput.text.Length > 0)
        userInput.text = userInput.text.Substring(0,userInput.text.Length-1);

    }
    private void EnterKey()
    {
        string val = userInput.text;

        val = val.Trim();
        val = val.Replace(" ", "");
        val = val.ToLower();

        if (val.Equals("superjump") && !playerController.bigJumpEnabled && playerController.canBigJump)
        {
            playerController.bigJumpEnabled = true;
            playerController.bigJump = true;
        }
        else if (val.Equals("superswipe") && !playerController.attackEnabled && playerController.bigJumpEnabled)
        {
            playerController.attackEnabled = true;
            playerController.superAttack = true;
        }
      
        
        mobileKeyboardPortrait.SetActive(false);
        mobileKeyboardLandscape.SetActive(false);
        mobileCmdPortrait.SetActive(false);
        mobileCmdLandscape.SetActive(false);
        playerController.mobileControls.SetActive(true);
        brickButton.transform.parent.GetComponent<Canvas>().sortingOrder = 9;
        brickButton2.transform.parent.GetComponent<Canvas>().sortingOrder = 9;
        userInput.text = "";

    }
  
   



    private void Start()
    {
        if (playerController.controls == Controls.Mobile)
        {
            AddListeners();
        }
        else if(playerController.controls==Controls.Pc)
        {
            userInput.onEndEdit.AddListener(Submitt);
            playerController.bigJumpEnabled = false;
        }
  

    }
    private void OnDestroy()
    {
     
        if (playerController.controls == Controls.Mobile)
        {
            RemoveListeners();
        }
        else if (playerController.controls == Controls.Pc)
        {
            userInput.onEndEdit.RemoveListener(Submitt);
        }
          
    }
 
 
    public void Submitt(string val)
    {
        //val = val.ToLower();
        val = val.Trim();
        val = val.Replace(" ","");
        val=val.ToLower();

        if(val.Equals("superjump") && !playerController.bigJumpEnabled && playerController.canBigJump)
        {
            playerController.bigJumpEnabled = true;
          playerController.bigJump = true;
        }
        else if(val.Equals("superswipe") && !playerController.attackEnabled && playerController.bigJumpEnabled)
        {
            playerController.attackEnabled = true;
            playerController.superAttack = true;
        }
        pcCmd.SetActive(false);
        userInput.text = "";


   
    }

}
