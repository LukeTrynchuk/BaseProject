using UnityEngine;
using UnityEngine.EventSystems;
using DogHouse.Services;
using DogHouse.Core.Services;

namespace Michsky.UI.FieldCompleteMainMenu
{
    public class UIElementSound : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler
    {
        private ServiceReference<IAudioService> m_audioService
            = new ServiceReference<IAudioService>();

        [Header("RESOURCES")]
        public AudioClip hoverSound;
        public AudioClip clickSound;
        public AudioClip notificationSound;

        [Header("SETTINGS")]
        public bool enableHoverSound = true;
        public bool enableClickSound = true;
        public bool isNotification = false;

        private AudioSource HoverSource => GetHoverSource();
        private AudioSource ClickSource => GetClickSource();
        private AudioSource NotificationSource => GetNotificationSource();

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (enableHoverSound == true)
            {
                HoverSource.PlayOneShot(hoverSound);
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (enableClickSound == true)
            {
                ClickSource.PlayOneShot(clickSound);
            }
        }

        public void Notification()
        {
            if (isNotification == true)
            {
                NotificationSource.PlayOneShot(notificationSound);
            }
        }

        private AudioSource GetHoverSource() => FetchSource(hoverSound);
        private AudioSource GetClickSource() => FetchSource(clickSound);
        private AudioSource GetNotificationSource() => FetchSource(notificationSound);

        private AudioSource FetchSource(AudioClip clip)
        {
            AudioSource source = m_audioService.Reference?
                                               .FetchAvailableAudioSource();
            if (source == null) return null;
            source.clip = clip;
            return source;
        }
    }
}