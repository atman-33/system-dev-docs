// ---- ---- 採用選考集約 ---- ---- //

/** 採用選考エンティティ */
export class Screening {
  /**
   * コンストラクタ
   * @param id 採用選考ID
   * @param _status 採用選考ステータス
   * @param applicationRoute 応募経路
   * @param applicant 応募者
   * @param positionId 採用ポジション（集約またぎの参照）
   * @param _interviews 面接
   */
  constructor (
    private id: ScreeningId,
    private _status: ScreeningStatus, 
    private applicationRoute: string,
    private applicant: Applicant,
    private positionId: PositionId,
    private _interviews: Interview[]
  ) {
  }

  get status() {
    return this._status;
  }

  get interviews() {
    return this._interviews;
  }

  addInterview(interviewDate: Date) {
    // 選考ステータスのバリデーション
    // 選考中でなければ、面接は追加できない。 → これがドメイン層の実装になった
    if(this.status !== ScreeningStatus.選考中) {
      // NOTE: DomainExceptionなど、ドメイン層に実装する例外に投げる方が良い
      throw new Error("選考中ではない採用選考に、面接を追加できません");
    }

    // 新しい面接を作成
    const newInterview = new Interview(
      // 2回目以降の面接は、「面接次数」が既存の最大値+1 → これがドメイン層の実装になった
      this.interviews.length + 1, 
      interviewDate);

    // 新しい面接を追加    
    this.interviews.push(newInterview);
  }
}

/** 採用選考ID（Value Object） */
export class ScreeningId {
  constructor(private id: string) {}
}

// ---- ---- ---- ---- ---- ---- ---- ----
// ドメインロジックをユースケースに書いてしまった悪いパターン
export class AddInterviewUseCase {
  constructor(
    private screeningRepository: ScreeningRepository
  ){}

  execute(screeningId: ScreeningId, interviewDate: Date) {
    // ---- 良い実装 ---- //
    // 採用選考を取得する。
    const screening = this.screeningRepository.findById(screeningId);
    if(!screening) {
      throw new Error("採用選考は見つかりません");
    };

    // 面接を追加する。
    screening.addInterview(interviewDate);
    // 採用選考を保存する。
    this.screeningRepository.update(screening);

    // ---- 悪い実装 ---- //
    /*
    const screening = this.screeningRepository.findById(screeningId);
    if(!screening) {
      throw new Error("採用選考は見つかりません");
    };

    // 選考ステータスのバリデーション
    // 選考中でなければ、面接は追加できない。 → これはドメイン層に書くべき
    if(screening.status !== ScreeningStatus.選考中) {
      throw new Error("選考中ではない採用選考に、面接を追加できません");
    }

    // 新しい面接を作成
    const newInterview = new Interview(
      // 2回目以降の面接は、「面接次数」が既存の最大値+1 → これはドメイン層に書くべき
      screening.interviews.length + 1, 
      interviewDate);

    // 新しい面接を追加    
    screening.interviews.push(newInterview);
    // screening.interviews = [new Interview(1, new Date())]; // setを開示していないため、代入不可
    */
  }
}
// ---- ---- ---- ---- ---- ---- ---- ----


/** 採用選考ステータス */
const ScreeningStatus = {
  "選考中": 0,
  "内定": 1,
  "内定承諾": 2,
  "入社" : 3,
  "不合格": 4
} as const

type ScreeningStatus = typeof ScreeningStatus[keyof typeof ScreeningStatus]

/** 採用選考リポジトリ */
export interface ScreeningRepository {
  insert(screening: Screening): void
  findById(screeningId: ScreeningId): Screening | undefined
  update(screening: Screening): void;
}

/** 応募者エンティティ */
export class Applicant {

  constructor(
    private name: string, 
    private email: string) {
  }
}

/** 面接エンティティ */
export class Interview {
  constructor(
    private interviewNumber: number,
    private interviewData: Date
  ){}
}

// ---- ---- 採用ポジション集約 ---- ---- //

// domain/entities/psition.ts
/** 採用ポジションエンティティ */
export class Positon {
  constructor(
    private id: PositionId,
    private name: string
  ){}
}

export interface PositionRepository {
  insert(positon: Positon): void
  findById(positionId: PositionId): Positon | undefined
}

export class PositionId {
  constructor(private id: string){}
}