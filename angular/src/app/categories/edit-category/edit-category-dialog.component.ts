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
  CategoriesServiceProxy,
  CategoryDto,
  CategoryTranslationDto
} from '@shared/service-proxies/service-proxies';
import { filter as _filter } from 'lodash-es';

@Component({
  templateUrl: 'edit-category-dialog.component.html'
})
export class EditCategoryDialogComponent extends AppComponentBase
  implements OnInit {
  saving = false;
  languages: abp.localization.ILanguageInfo[];
  langTranslation: CategoryTranslationDto[] = [];
  category: CategoryDto = new CategoryDto();
  id: number;

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

    this._categoryService.get(this.id).subscribe((result: CategoryDto) => {
      this.category = result;
      this.languages.forEach(lang => {
        this.langTranslation[lang.name] = CategoryTranslationDto.fromJS({
          name: this.category.translations?.find(pt => pt.language === lang.name)?.name,
          description: this.category.translations?.find(pt => pt.language === lang.name)?.description,
          language: lang.name
        });
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

    this._categoryService.update(this.category).subscribe(
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
