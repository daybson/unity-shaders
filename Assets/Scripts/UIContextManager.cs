﻿using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AdrianMiasik
{
    public class UIContextManager : MonoBehaviour
    {
        [SerializeField] private List<DisplayCaseCarousel> selector = null;
        [SerializeField] private TitleLabel sourceTitleLabelPrefab = null;
        
        // Cache
        private TitleLabel currentLabel = null;

        public void Start()
        {
            foreach (DisplayCaseCarousel _carousel in selector)
            {
                // Subscribe to selection changes
                _carousel.onDisplayChange += OnSelectionChange;
            }
            
            // Spawn a label based on the last added carousel
            currentLabel = SpawnLabel(selector[selector.Count - 1].GetShader().ToString());
        }
        
        private void OnSelectionChange(DisplayCase _previousCase, DisplayCase _currentCase)
        {
            currentLabel.Hide();
            
            // Create and cache a new label
            currentLabel = SpawnLabel(_currentCase.GetShader().ToString());
        }

        // TODO: Spawner
        private TitleLabel SpawnLabel(string _message)
        {
            TitleLabel _label = Instantiate(sourceTitleLabelPrefab, transform);
            _label.Initialize(_message);
            return _label;
        }
    }
}