/*
void crouchingAbility()
    {
        RaycastHit2D roofHit = Physics2D.Raycast(halfBoxCol.bounds.center, Vector2.up, 2f, crouchLayMask);
        if (roofHit.collider != null)
        {
             roof = true;
             Debug.Log("rood true");
        }
        else
        {
            roof = false;
            Debug.Log("roof false");
        }
        if (Input.GetButton("crouch"))
        {
            boxCol.enabled = false;
            crouching = true;
            Debug.Log(crouching);
        }
        else
        {
            if (roof)
            {
                crouching = true;
                boxCol.enabled = false;
            }
            else
            {
                crouching = false;
                boxCol.enabled = true;
            }
        }
    }
*/