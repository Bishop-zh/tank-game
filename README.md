# TankGame - Unity 坦克大战练习项目

[在线试玩](https://bishop-zh.github.io/tank-game/) · [WebGL 构建与发布](WEBGL.md)


> 本项目是跟随 **唐老狮 Unity 基础教程** 学习制作的练手小游戏，仅供学习交流使用。

## 🎮 项目简介

这是一个基于 Unity 开发的 3D 坦克对战小游戏，包含以下核心玩法：
- 玩家控制坦克移动、旋转炮塔、发射子弹
- 敌方坦克 AI 巡逻、追踪、自动攻击
- 拾取道具强化属性（伤害、射速、移速、血量、防御）
- 计分系统、血量显示、武器冷却 UI
- 简单的特效系统（开火、爆炸、拾取）

## 🛠 技术栈

| 类别 | 使用技术 |
|------|----------|
| **引擎** | Unity 2022+ |
| **UI** | IMGUI (OnGUI) - *教学阶段使用，后续建议迁移至 UGUI* |
| **物理** | 内置 Physics (Rigidbody + Collider) |
| **数据持久化** | PlayerPrefs (两套封装：DataManager + PlayerPrefsDataMgr) |
| **架构模式** | 单例模式、继承多态、简单工厂 |
| **资源管理** | Resources + 直接引用 |

## 📁 核心脚本结构

```
Assets/Scripts/
├── Tank/           # 坦克核心 (基类、玩家、武器、子弹)
├── Enemy/          # 敌人 AI (巡逻、攻击、掉落)
├── UI/             # 界面面板 (开始、设置、游戏中、结算)
├── Effects/        # 简易特效
├── Collection/     # 道具收集 (武器、属性、结算)
├── DataManager/    # 数据存储
├── PlayerPrefsDataMgr/ # 通用反射存储
└── 实践小项目/CustomGUI/ # 自研 IMGUI 控件库
```

## 🎯 学习收获

通过本项目练习了：
- Unity 基础组件使用 (Transform、Rigidbody、Collider、Renderer)
- MonoBehaviour 生命周期 (Awake/Start/Update/FixedUpdate/OnGUI)
- 面向对象设计 (继承、虚函数、多态)
- 协程与时间控制
- Prefab 与 Instantiate 物体池雏形
- PlayerPrefs 本地数据存储
- 简单 AI 状态机 (巡逻 → 追击 → 攻击)

## ⚠️ 已知问题 & 后续优化方向

- [ ] **UI 迁移**：将 IMGUI 替换为 UGUI/Unity UI (Canvas + RectTransform)
- [ ] **对象池**：子弹、特效、敌人频繁实例化销毁，需引入对象池
- [ ] **解耦**：GameSceneUI 静态方法被多处直接调用，建议引入事件总线/接口
- [ ] **数据层统一**：DataManager 与 PlayerPrefsDataMgr 功能重叠
- [ ] **配置外置**：魔法数字硬编码，应使用 ScriptableObject 配置表
- [ ] **输入系统**：迁移至新 Input System 支持手柄/键位重绑定
- [ ] **Assembly Definition**：划分程序集加速编译
- [ ] **单元测试**：引入 NUnit + Unity Test Runner

## 📚 参考教程

- **唐老狮 Unity 入门到精通系列** (B 站/网易云课堂)
- Unity 官方文档 & API 参考

## 📄 许可证

本项目仅供个人学习使用，美术资源版权归原作者所有，请勿商用。

---

> **提示**：这是一个教学练手项目，代码规范、架构设计、性能优化等方面还有很大提升空间，欢迎交流指正！