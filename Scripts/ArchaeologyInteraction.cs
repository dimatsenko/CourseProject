using UnityEngine;
using UnityEngine.Tilemaps;

public class ArchaeologyInteraction : MonoBehaviour
{
    public Tilemap excavationTilemap;
    public TileBase excavationTile;
    public KeyCode interactionKey = KeyCode.E;
    public float excavationDuration = 7f;

    private bool isExcavating = false;
    public float excavationTimer = 0f;

    public bool IsExcavating => isExcavating; // Властивість для перевірки, чи триває копання
    public float ExcavationProgress => excavationTimer / excavationDuration; // Властивість для отримання прогресу

    void Update()
    {
        if (Input.GetKey(interactionKey))
        {
            if (!isExcavating)
            {
                StartExcavationTimer();
            }
            else
            {
                ContinueExcavation();
            }
        }
        else
        {
            StopExcavation();
        }
    }

    public void StartExcavationTimer()
    {
        isExcavating = true;
        excavationTimer = 0f;
    }

    void ContinueExcavation()
    {
        excavationTimer += Time.deltaTime;

        if (excavationTimer >= excavationDuration)
        {
            TryExcavate();
            StopExcavation();
        }
    }

    public void StopExcavation()
    {
        isExcavating = false;
        excavationTimer = 0f;
    }

    void TryExcavate()
    {
        Vector3Int playerCellPosition = excavationTilemap.WorldToCell(transform.position);

        TileBase tile = excavationTilemap.GetTile(playerCellPosition);

        if (tile == excavationTile)
        {
            ExcavationSite excavationSite = GetExcavationSiteComponent(playerCellPosition);

            if (excavationSite != null)
            {
                excavationTilemap.SetTile(playerCellPosition, null);
                excavationSite.StartExcavation();
            }
        }
    }

    ExcavationSite GetExcavationSiteComponent(Vector3Int cellPosition)
    {
        Collider2D[] colliders = Physics2D.OverlapPointAll(excavationTilemap.GetCellCenterWorld(cellPosition));

        foreach (var collider in colliders)
        {
            ExcavationSite excavationSite = collider.GetComponent<ExcavationSite>();
            if (excavationSite != null)
            {
                return excavationSite;
            }
        }

        return null;
    }


}

