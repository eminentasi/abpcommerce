import {
  Component,
  Injector,
  OnInit,
  Output,
  EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
  CategoryDto,
  CategoriesServiceProxy,
  CategoryTranslationDto
} from '@shared/service-proxies/service-proxies';
import { filter as _filter } from 'lodash-es';

@Component({
  templateUrl: 'create-category-dialog.component.html'
})
export class CreateCategoryDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  category: CategoryDto = new CategoryDto();
  languages: abp.localization.ILanguageInfo[];
  langTranslation: CategoryTranslationDto[] = [];

  @Output() onSave = new EventEmitter<any>();

  constructor(
    injector: Injector,
    public _categoryService: CategoriesServiceProxy,
    public bsModalRef: BsModalRef
  ) {
    super(injector);
  }

  ngOnInit(): void {
    this.languages = _filter(
      this.localization.languages,
      (l) => !l.isDisabled
    );

    this.languages.forEach(lang => {
      this.langTranslation[lang.name] = CategoryTranslationDto.fromJS({
        language: lang.name
      });
    });
  }

  save(): void {
    this.saving = true;

    this.category.translations = Object.keys(this.langTranslation).map(k => {
      if (this.langTranslation[k].name) {
        return this.langTranslation[k];
      } 
    }).filter(el => el);
    
    this._categoryService.create(this.category).subscribe(
      () => {
        this.notify.info(this.l('SavedSuccessfully'));
        this.bsModalRef.hide();
        this.onSave.emit();
      },
      () => {
        this.saving = false;
      }
    );
  }
}
