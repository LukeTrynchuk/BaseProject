
var camelCaseTokenizer = function (builder) {

  var pipelineFunction = function (token) {
    var previous = '';
    // split camelCaseString to on each word and combined words
    // e.g. camelCaseTokenizer -> ['camel', 'case', 'camelcase', 'tokenizer', 'camelcasetokenizer']
    var tokenStrings = token.toString().trim().split(/[\s\-]+|(?=[A-Z])/).reduce(function(acc, cur) {
      var current = cur.toLowerCase();
      if (acc.length === 0) {
        previous = current;
        return acc.concat(current);
      }
      previous = previous.concat(current);
      return acc.concat([current, previous]);
    }, []);

    // return token for each string
    // will copy any metadata on input token
    return tokenStrings.map(function(tokenString) {
      return token.clone(function(str) {
        return tokenString;
      })
    });
  }

  lunr.Pipeline.registerFunction(pipelineFunction, 'camelCaseTokenizer')

  builder.pipeline.before(lunr.stemmer, pipelineFunction)
}
var searchModule = function() {
    var documents = [];
    var idMap = [];
    function a(a,b) { 
        documents.push(a);
        idMap.push(b); 
    }

    a(
        {
            id:0,
            title:"CameraFinder",
            content:"CameraFinder",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/CameraFinder',
            title:"CameraFinder",
            description:""
        }
    );
    a(
        {
            id:1,
            title:"UnityAnalyticsService",
            content:"UnityAnalyticsService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/UnityAnalyticsService',
            title:"UnityAnalyticsService",
            description:""
        }
    );
    a(
        {
            id:2,
            title:"SheetsDemo",
            content:"SheetsDemo",
            description:'',
            tags:''
        },
        {
            url:'/api/global/SheetsDemo',
            title:"SheetsDemo",
            description:""
        }
    );
    a(
        {
            id:3,
            title:"ImageColorController",
            content:"ImageColorController",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.UI/ImageColorController',
            title:"ImageColorController",
            description:""
        }
    );
    a(
        {
            id:4,
            title:"CameraTransitionState",
            content:"CameraTransitionState",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/CameraTransitionState',
            title:"CameraTransitionState",
            description:""
        }
    );
    a(
        {
            id:5,
            title:"IRemoteSettingsService",
            content:"IRemoteSettingsService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/IRemoteSettingsService',
            title:"IRemoteSettingsService",
            description:""
        }
    );
    a(
        {
            id:6,
            title:"BaseService",
            content:"BaseService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Services/BaseService_1',
            title:"BaseService<T>",
            description:""
        }
    );
    a(
        {
            id:7,
            title:"RemoteCSVReaderBackdoor",
            content:"RemoteCSVReaderBackdoor",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/RemoteCSVReaderBackdoor',
            title:"RemoteCSVReaderBackdoor",
            description:""
        }
    );
    a(
        {
            id:8,
            title:"ISceneManager",
            content:"ISceneManager",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/ISceneManager',
            title:"ISceneManager",
            description:""
        }
    );
    a(
        {
            id:9,
            title:"AudioAsset",
            content:"AudioAsset",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Audio/AudioAsset',
            title:"AudioAsset",
            description:""
        }
    );
    a(
        {
            id:10,
            title:"IAnalyticsService",
            content:"IAnalyticsService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/IAnalyticsService',
            title:"IAnalyticsService",
            description:""
        }
    );
    a(
        {
            id:11,
            title:"ReleaseNotesService",
            content:"ReleaseNotesService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/ReleaseNotesService',
            title:"ReleaseNotesService",
            description:""
        }
    );
    a(
        {
            id:12,
            title:"SheetTypesDemo",
            content:"SheetTypesDemo",
            description:'',
            tags:''
        },
        {
            url:'/api/global/SheetTypesDemo',
            title:"SheetTypesDemo",
            description:""
        }
    );
    a(
        {
            id:13,
            title:"ICameraTransition",
            content:"ICameraTransition",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/ICameraTransition',
            title:"ICameraTransition",
            description:""
        }
    );
    a(
        {
            id:14,
            title:"OnStart",
            content:"OnStart",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Mono/OnStart',
            title:"OnStart",
            description:""
        }
    );
    a(
        {
            id:15,
            title:"LogService",
            content:"LogService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/LogService',
            title:"LogService",
            description:""
        }
    );
    a(
        {
            id:16,
            title:"InvokeButtonOnClick",
            content:"InvokeButtonOnClick",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.UI/InvokeButtonOnClick',
            title:"InvokeButtonOnClick",
            description:""
        }
    );
    a(
        {
            id:17,
            title:"OnEnableDisable",
            content:"OnEnableDisable",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Mono/OnEnableDisable',
            title:"OnEnableDisable",
            description:""
        }
    );
    a(
        {
            id:18,
            title:"ILogService",
            content:"ILogService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/ILogService',
            title:"ILogService",
            description:""
        }
    );
    a(
        {
            id:19,
            title:"VersionCheck",
            content:"VersionCheck",
            description:'',
            tags:''
        },
        {
            url:'/api/global/VersionCheck',
            title:"VersionCheck",
            description:""
        }
    );
    a(
        {
            id:20,
            title:"DoNotDestroyOnLoad",
            content:"DoNotDestroyOnLoad",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.GameObject/DoNotDestroyOnLoad',
            title:"DoNotDestroyOnLoad",
            description:""
        }
    );
    a(
        {
            id:21,
            title:"GoSheets",
            content:"GoSheets",
            description:'',
            tags:''
        },
        {
            url:'/api/global/GoSheets',
            title:"GoSheets",
            description:""
        }
    );
    a(
        {
            id:22,
            title:"IService",
            content:"IService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Services/IService',
            title:"IService",
            description:""
        }
    );
    a(
        {
            id:23,
            title:"SplashScreen",
            content:"SplashScreen",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Logo/SplashScreen',
            title:"SplashScreen",
            description:""
        }
    );
    a(
        {
            id:24,
            title:"AudioChannel",
            content:"AudioChannel",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/AudioChannel',
            title:"AudioChannel",
            description:""
        }
    );
    a(
        {
            id:25,
            title:"ServiceReference",
            content:"ServiceReference",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Services/ServiceReference_1',
            title:"ServiceReference<T>",
            description:""
        }
    );
    a(
        {
            id:26,
            title:"SplashScreenPlayer",
            content:"SplashScreenPlayer",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Logo/SplashScreenPlayer',
            title:"SplashScreenPlayer",
            description:""
        }
    );
    a(
        {
            id:27,
            title:"AudioService",
            content:"AudioService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/AudioService',
            title:"AudioService",
            description:""
        }
    );
    a(
        {
            id:28,
            title:"IInputService",
            content:"IInputService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/IInputService',
            title:"IInputService",
            description:""
        }
    );
    a(
        {
            id:29,
            title:"ServiceLocator",
            content:"ServiceLocator",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Services/ServiceLocator',
            title:"ServiceLocator",
            description:""
        }
    );
    a(
        {
            id:30,
            title:"UnityBuiltInSceneManager",
            content:"UnityBuiltInSceneManager",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/UnityBuiltInSceneManager',
            title:"UnityBuiltInSceneManager",
            description:""
        }
    );
    a(
        {
            id:31,
            title:"IFileReaderService",
            content:"IFileReaderService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/IFileReaderService',
            title:"IFileReaderService",
            description:""
        }
    );
    a(
        {
            id:32,
            title:"LocalizationService",
            content:"LocalizationService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/LocalizationService',
            title:"LocalizationService",
            description:""
        }
    );
    a(
        {
            id:33,
            title:"IAudioService",
            content:"IAudioService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/IAudioService',
            title:"IAudioService",
            description:""
        }
    );
    a(
        {
            id:34,
            title:"IReleaseNotesService",
            content:"IReleaseNotesService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/IReleaseNotesService',
            title:"IReleaseNotesService",
            description:""
        }
    );
    a(
        {
            id:35,
            title:"IRemoteCSVReader",
            content:"IRemoteCSVReader",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/IRemoteCSVReader',
            title:"IRemoteCSVReader",
            description:""
        }
    );
    a(
        {
            id:36,
            title:"SceneManagerBackdoor",
            content:"SceneManagerBackdoor",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/SceneManagerBackdoor',
            title:"SceneManagerBackdoor",
            description:""
        }
    );
    a(
        {
            id:37,
            title:"InputState",
            content:"InputState",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/InputState',
            title:"InputState",
            description:""
        }
    );
    a(
        {
            id:38,
            title:"FileReaderService",
            content:"FileReaderService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/FileReaderService',
            title:"FileReaderService",
            description:""
        }
    );
    a(
        {
            id:39,
            title:"OnUpdate",
            content:"OnUpdate",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Mono/OnUpdate',
            title:"OnUpdate",
            description:""
        }
    );
    a(
        {
            id:40,
            title:"InputMethodController",
            content:"InputMethodController",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/InputMethodController',
            title:"InputMethodController",
            description:""
        }
    );
    a(
        {
            id:41,
            title:"GoogleSheetsRemoteCSVReader",
            content:"GoogleSheetsRemoteCSVReader",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/GoogleSheetsRemoteCSVReader',
            title:"GoogleSheetsRemoteCSVReader",
            description:""
        }
    );
    a(
        {
            id:42,
            title:"LoadingScreenService",
            content:"LoadingScreenService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/LoadingScreenService',
            title:"LoadingScreenService",
            description:""
        }
    );
    a(
        {
            id:43,
            title:"ILoadingScreenService",
            content:"ILoadingScreenService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/ILoadingScreenService',
            title:"ILoadingScreenService",
            description:""
        }
    );
    a(
        {
            id:44,
            title:"SceneManagerState",
            content:"SceneManagerState",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/SceneManagerState',
            title:"SceneManagerState",
            description:""
        }
    );
    a(
        {
            id:45,
            title:"InvokeInSeconds",
            content:"InvokeInSeconds",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Timing/InvokeInSeconds',
            title:"InvokeInSeconds",
            description:""
        }
    );
    a(
        {
            id:46,
            title:"SheetsLocalization",
            content:"SheetsLocalization",
            description:'',
            tags:''
        },
        {
            url:'/api/global/SheetsLocalization',
            title:"SheetsLocalization",
            description:""
        }
    );
    a(
        {
            id:47,
            title:"TimingState",
            content:"TimingState",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Core.Timing/TimingState',
            title:"TimingState",
            description:""
        }
    );
    a(
        {
            id:48,
            title:"ILocalizationService",
            content:"ILocalizationService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/ILocalizationService',
            title:"ILocalizationService",
            description:""
        }
    );
    a(
        {
            id:49,
            title:"UnityRemoteSettings",
            content:"UnityRemoteSettings",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/UnityRemoteSettings',
            title:"UnityRemoteSettings",
            description:""
        }
    );
    a(
        {
            id:50,
            title:"ICameraFinder",
            content:"ICameraFinder",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/ICameraFinder',
            title:"ICameraFinder",
            description:""
        }
    );
    a(
        {
            id:51,
            title:"GamepadInput",
            content:"GamepadInput",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.General/GamepadInput',
            title:"GamepadInput",
            description:""
        }
    );
    a(
        {
            id:52,
            title:"SetReleaseNoteUpdateText",
            content:"SetReleaseNoteUpdateText",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/SetReleaseNoteUpdateText',
            title:"SetReleaseNoteUpdateText",
            description:""
        }
    );
    a(
        {
            id:53,
            title:"AudioMixerService",
            content:"AudioMixerService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/AudioMixerService',
            title:"AudioMixerService",
            description:""
        }
    );
    a(
        {
            id:54,
            title:"CameraTransition",
            content:"CameraTransition",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/CameraTransition',
            title:"CameraTransition",
            description:""
        }
    );
    a(
        {
            id:55,
            title:"SheetsBenchmark",
            content:"SheetsBenchmark",
            description:'',
            tags:''
        },
        {
            url:'/api/global/SheetsBenchmark',
            title:"SheetsBenchmark",
            description:""
        }
    );
    a(
        {
            id:56,
            title:"KeyboardAndMouseInput",
            content:"KeyboardAndMouseInput",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/KeyboardAndMouseInput',
            title:"KeyboardAndMouseInput",
            description:""
        }
    );
    a(
        {
            id:57,
            title:"AnalyticsServiceBackdoor",
            content:"AnalyticsServiceBackdoor",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/AnalyticsServiceBackdoor',
            title:"AnalyticsServiceBackdoor",
            description:""
        }
    );
    a(
        {
            id:58,
            title:"IAudioMixerService",
            content:"IAudioMixerService",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/IAudioMixerService',
            title:"IAudioMixerService",
            description:""
        }
    );
    a(
        {
            id:59,
            title:"AudioServiceBackdoor",
            content:"AudioServiceBackdoor",
            description:'',
            tags:''
        },
        {
            url:'/api/DogHouse.Services/AudioServiceBackdoor',
            title:"AudioServiceBackdoor",
            description:""
        }
    );
    var idx = lunr(function() {
        this.field('title');
        this.field('content');
        this.field('description');
        this.field('tags');
        this.ref('id');
        this.use(camelCaseTokenizer);

        this.pipeline.remove(lunr.stopWordFilter);
        this.pipeline.remove(lunr.stemmer);
        documents.forEach(function (doc) { this.add(doc) }, this)
    });

    return {
        search: function(q) {
            return idx.search(q).map(function(i) {
                return idMap[i.ref];
            });
        }
    };
}();