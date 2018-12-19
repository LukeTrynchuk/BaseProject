using DogHouse.Core.Services;
using UnityEngine;
using UnityEngine.UI;

namespace DogHouse.Services
{
    /// <summary>
    /// SetReleaseNoteUpdateText will take in a
    /// text component and set the text value
    /// equal to the release notes available.
    /// </summary>
    public class SetReleaseNoteUpdateText : MonoBehaviour 
    {
        #region Private Variables
        [SerializeField]
        private Text m_text = default(Text);

        private ServiceReference<IReleaseNotesService> m_releaseNotes 
            = new ServiceReference<IReleaseNotesService>();
        #endregion

        #region Main Methods
        private void Start()
        {
            m_text.text = m_releaseNotes.Reference?.FetchReleaseNotes();
        }
        #endregion
    }
}
